using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssetBundleManager : Singleton<AssetBundleManager>
{
    //主包
    private AssetBundle MainPackage = null;
    //依赖包配置文件
    private AssetBundleManifest manifest=null;
    //存储加载过的资源包
    private Dictionary<string, AssetBundle> ab_LoadedPackageDic = new Dictionary<string, AssetBundle>();

    private string PathUrl { get { return Application.streamingAssetsPath + "/"; } }
    private string MainABName { get {
    #if UNITY_IOS
                return "IOS";
    #elif UNITY_ANDROID
                return "ANDROID";
    #else 
                return "PC";
    #endif
            } }
    //
    public void LoadAb(string abName)
    {
        //加载主包及依赖配置文件
        if (MainPackage == null)
        {
            MainPackage = AssetBundle.LoadFromFile(PathUrl + MainABName);
            manifest = MainPackage.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }
        //获取依赖包相关信息
        AssetBundle Temp_ab = null;
        string[] strs = manifest.GetAllDependencies(abName);
        foreach (var item in strs)
        {
            if (!ab_LoadedPackageDic.ContainsKey(item))
            {
                Temp_ab = AssetBundle.LoadFromFile(PathUrl + item);
                ab_LoadedPackageDic.Add(item, Temp_ab);
            }
        }
        //加载必要的资源包
        if (!ab_LoadedPackageDic.ContainsKey(abName))
        {
            Temp_ab = AssetBundle.LoadFromFile(PathUrl + abName);
            ab_LoadedPackageDic.Add(abName, Temp_ab);
        }
    }

    #region 同步加载
    public Object LoadRes(string abName, string resName)
    {
        LoadAb(abName);
        //加载资源
        return ab_LoadedPackageDic[abName].LoadAsset(resName);
    }
    public Object LoadRes(string abName, string resName,System.Type type)
    {
        LoadAb(abName);
        //加载资源,指定类型
        return ab_LoadedPackageDic[abName].LoadAsset(resName, type);
    }
    public T LoadRes<T>(string abName, string resName,System.Type type) where T: Object
    {
        LoadAb(abName);
        //加载资源,使用泛型
        return ab_LoadedPackageDic[abName].LoadAsset<T>(resName);
    }
    #endregion

    #region 卸载
    public void UnLoadSinglePkg(string abName)
    {
        if (ab_LoadedPackageDic.ContainsKey(abName))
        {
            ab_LoadedPackageDic[abName].Unload(false);
            ab_LoadedPackageDic.Remove(abName);
        }
    }
    public void UnAllPkg()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        ab_LoadedPackageDic.Clear();
        MainPackage = null;
        manifest = null;
    }
    #endregion

    #region 异步加载(资源)
    private IEnumerator ReadyLoadResAsync(string abName, string resName, UnityAction<Object> callback)
    {
        AssetBundleRequest abr = ab_LoadedPackageDic[abName].LoadAssetAsync(resName);
        yield return abr;
        if (abr.asset is  GameObject)
        {
            callback(Instantiate(abr.asset));
        }
        else
        {
            callback(abr.asset);
        }
    }
    public void LoadresAsync(string abName,string resName,UnityAction<Object> callback)
    {
        StartCoroutine(ReadyLoadResAsync(abName, resName, callback));
    }
    #endregion

}
