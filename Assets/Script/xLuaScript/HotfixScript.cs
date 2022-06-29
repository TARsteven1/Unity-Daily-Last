using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using XLua;
[Hotfix]
public class HotfixScript : MonoBehaviour
{
    private LuaEnv luaEnv;
    public HotfixScript hot;
    public Dictionary<string,GameObject> prafabs = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {
        hot = this;
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyLoader);
        luaEnv.DoString("require'Test'");
    }
    private byte[] MyLoader(ref string filepath)
    {
        string temppath = @"D:\Unity3D program\Unity Daily Last\XLua\Lua\" + filepath + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(temppath));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        luaEnv.DoString("require'InitFun'");
    }
    private void OnDestroy()
    {
        luaEnv.Dispose();
    }
    [LuaCallCSharp]
    public void LoadResource(string resName,string filePath)
    {
        StartCoroutine(Load(resName, filePath));
    }
    IEnumerator Load(string resName, string filePath)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(@"http://localhost/AssetBundles/StandaloneWindows/" + filePath);

        yield return request.SendWebRequest();
        AssetBundle assetBundle = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        GameObject go = assetBundle.LoadAsset<GameObject>(resName);
        prafabs.Add(resName,go);
    }
    [LuaCallCSharp]
    public GameObject GetPrefab(string resName)
    {
        Debug.Log("ab loaded!");
        Instantiate(prafabs[resName]);
        return prafabs[resName];
    }
}
