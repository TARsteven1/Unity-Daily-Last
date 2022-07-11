using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

public class Other : MonoBehaviour
{
    int LastTime = 220728;
    //string ret = "null";
    [ContextMenu("TTR")]
    public void TestReVal()
    {
        
         StartCoroutine(uploadPoints("1", 1, 1, 1, (result) =>
        {
            Debug.Log("Result:" + result);
            string  ret = result;
            PrintRet(ret);


        }));
        //Debug.Log("Result:" + ret);
        //return result;
    }
    [ContextMenu("TTT")]
    public async void UseThreadingFun()
    {
        string tempstr =await HelpHandler.LoadSpritePNG();
        Debug.Log("UseThreadingFun:" + tempstr);
    }
    [ContextMenu("TTE")]
    public void TheadingFun()
    {
        Thread thread = new Thread(TheadingOrignFun);
        thread.Start();
    }
    private void TheadingOrignFun()
    {
        //unity中次线程只能处理数据,不能对object进行操作
        //UnityWebRequest req = UnityWebRequest.Get("http://localhost/");

        Thread.Sleep(100);
        // req.SendWebRequest();
        Debug.Log("first:" +"1");
    }


    public void PrintRet(string v)
    {
        Debug.Log("ret:" + v);
    }

    public void UpLoadPoints(string token, int mobile, int game_id, int points)
    {
        //if (!CheckingUsefully())
        //{
        //    Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
        //    return;
        //}
       StartCoroutine(uploadPoints(token, mobile, game_id, points, (result) =>
       {
           Debug.Log("Result:" + result);
       }));
    }    
    public void GetPointsRanking(string token, int mobile, int game_id)
    {
        if (!CheckingUsefully())
        {
            Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
            return;
        }
        StartCoroutine(getpointsRanking(token, mobile, game_id));
    }
    IEnumerator  uploadPoints(string token,int mobile, int game_id,int points, Action<string> result)
    {
        //string fileName = Application.persistentDataPath + "/temp/321.mp3";
        //string fileName = Application.persistentDataPath + "\\words123.mp3";
       // byte[] body = System.IO.File.ReadAllBytes(fileName);
        // byte[] body = GameUtil.SafeReadAllByte(fileName);
        //UnityWebRequest req = UnityWebRequest.Put("http://127.0.0.1:6080/upload", body);
        UnityWebRequest req = UnityWebRequest.Get("http://localhost/");
        yield return req.SendWebRequest();//解决请求时卡顿，解放线程
        Debug.Log("first:"+req.downloadHandler.text);
        if (result != null)
            result(req.downloadHandler.text);
        //yield break;

    }
    IEnumerator getpointsRanking(string token, int mobile, int game_id)
    {
        Debug.Log("发送回复");
        //UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/uploadData");
        UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/uploadData?uname=black&upwd=123456");
        yield return req.SendWebRequest();//解决请求时卡顿，解放线程

        Debug.Log("等待回复");
        Debug.Log(req.downloadHandler.text);
    }

    private bool CheckingUsefully()
    {
        
        Debug.Log(DateTime.Now.ToString("yyMMdd"));
        return int.Parse(DateTime.Now.ToString("yyMMdd"))<= LastTime;
    }



}
public static class ExtensionMethods
{
    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<object>();
        asyncOp.completed += obj => { tcs.SetResult(null); };
        return ((Task)tcs.Task).GetAwaiter();
    }
}
public static class HelpHandler
{
    public static async Task<string> LoadSpritePNG()
    {
        var task = GetServerString();
        Task<string> t = await Task.WhenAny(task);
        return t.Result;
    }
    static async Task<string> GetServerString()
    {
        UnityWebRequest req = UnityWebRequest.Get("http://localhost/");
        await req.SendWebRequest();
        //Debug.Log("Result:" + req.downloadHandler.text);
        string tempt = req.downloadHandler.text;
        return tempt;
    }
}
