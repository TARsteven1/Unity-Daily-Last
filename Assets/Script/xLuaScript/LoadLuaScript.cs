using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using XLua;
using System.IO;

public class LoadLuaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(LoadLuaScriptFromServer("InitFun.lua.txt"));
       StartCoroutine(LoadLuaScriptFromServer("Test.lua.txt"));
        //CheckingUpdateData();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckingUpdateData();
    }
    IEnumerator LoadLuaScriptFromServer(string resName)
    {
        UnityWebRequest request = UnityWebRequest.Get(@"http://localhost/LuaScript/"+ resName);
        //UnityWebRequest request = UnityWebRequest.Get(@"http://localhost/LuaScript/InitFun.lua.txt");
        yield return request.SendWebRequest();

        string str = request.downloadHandler.text;
        //Debug.Log(request.downloadHandler.text);
        //if (!File.Exists(@"D: \rrr\" + resName)){
        //    File.Create(@"D: \rrr\" + resName);
        //File.WriteAllText(@"D: \rrr\" + resName,str);
        //}
        //else
        //{
        //File.WriteAllText(@"D: \rrr\" + resName,str);

        //}
        File.WriteAllText(@"D:\Unity3D program\Unity Daily Last\XLua\Lua" + resName, str);

    }
    private void CheckingUpdateData()
    {
        //判断是否有此文件夹
        if (File.Exists(@"D:\Unity3D program\Unity Daily Last\XLua\Lua\Test.lua.txt")&& File.Exists(@"D:\Unity3D program\Unity Daily Last\XLua\Lua\InitFun.lua.txt"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.Log("loading");
        }
    }
}
