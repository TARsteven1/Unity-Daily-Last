using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace NetWorkingAPI
{
    public static class PointsHandler/* : MonoBehaviour*/
    {

      static  int LastTime = 220728;


            public static void UpLoadPoints(string token, int mobile, int game_id, int points)
        {
            if (!CheckingUsefully())
            {
                Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
                return;
            }
            


        }
        public static IEnumerator UserLogin(string path,byte[] body, Action<string> result)
        {
            if (!CheckingUsefully())
            {
                Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
                yield break;
            }
            UnityWebRequest request = new UnityWebRequest(/*"http://cmcc.dwtv.tv/user/uploadPoints"*/path, "POST");//method传输方式，默认为Get；
            request.uploadHandler = new UploadHandlerRaw(body);//实例化上传缓存器
            request.downloadHandler = new DownloadHandlerBuffer();//实例化下载存贮器
            request.SetRequestHeader("Content-Type", "application/json");//更改内容类型，
            yield return request.SendWebRequest();//解决请求时卡顿，解放线程
            Debug.Log(request.downloadHandler.text);
            if (result != null)
                result(request.downloadHandler.text);
            yield break;
        }
            public static  IEnumerator uploadPoints(string path, byte[] body, Action<string> result)
        {

            //string fileName = Application.persistentDataPath + "/temp/321.mp3";
            if (!CheckingUsefully())
            {
                Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
                yield break;
            }
            UnityWebRequest request = new UnityWebRequest(/*"http://cmcc.dwtv.tv/user/uploadPoints"*/path, "POST");//method传输方式，默认为Get；
            request.uploadHandler = new UploadHandlerRaw(body);//实例化上传缓存器
            request.downloadHandler = new DownloadHandlerBuffer();//实例化下载存贮器
            request.SetRequestHeader("Content-Type", "application/json");//更改内容类型，
            yield return request.SendWebRequest();//解决请求时卡顿，解放线程
            Debug.Log(request.downloadHandler.text);

            if (result != null)
                result(request.downloadHandler.text);
            yield break;

        }
        public static IEnumerator getpointsRanking(string path, string token, string mobile, string game_id, Action<string> result)
        {
            if (!CheckingUsefully())
            {
                Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
                yield break;
            }
            string tempPath = path + @"?token=" + token + @"&mobile=" + mobile + @"&game_id=" + game_id;
            Debug.Log(tempPath);
            //UnityWebRequest req = UnityWebRequest.Get(/*"http://127.0.0.1:6080/uploadData?uname=black&upwd=123456"*/path+ "?token=" + token+ "&mobile="+mobile+ "&game_id="+ game_id);
            UnityWebRequest req = UnityWebRequest.Get(tempPath);
            yield return req.SendWebRequest();//解决请求时卡顿，解放线程

            //Debug.Log("等待回复");
            //Debug.Log(req.downloadHandler.text);
            if (result != null)
                result(req.downloadHandler.text);
        }

        private static bool CheckingUsefully()
        {

            //Debug.Log(DateTime.Now.ToString("yyMMdd"));
            return int.Parse(DateTime.Now.ToString("yyMMdd")) <= LastTime;
        }

        public static string TestDll(string val)
        {
            if (val == "")
            {
                return "null";
            }
            else
            {
                return val;
            }
        }
       


    }
}
