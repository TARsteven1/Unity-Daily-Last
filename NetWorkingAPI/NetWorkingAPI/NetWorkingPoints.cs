using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace NetWorkingAPI
{
    public static class NetWorkingPoints/* : MonoBehaviour*/
    {

      static  int LastTime = 220728;

        public static void UpLoadPoints(string token, int mobile, int game_id, int points)
        {
            if (!CheckingUsefully())
            {
                Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
                return;
            }
            //StartCoroutine(uploadPoints(token, mobile, game_id, points));


        }
        // public static  void GetPointsRanking(string token, int mobile, int game_id)
        // {
        //     if (!CheckingUsefully())
        //     {
        //         Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
        //         return;
        //     }
        //    // StartCoroutine(getpointsRanking(token, mobile, game_id));
        // }
        public static  IEnumerator uploadPoints(string token, int mobile, int game_id, int points, Action<string> result)
        {

            //string fileName = Application.persistentDataPath + "/temp/321.mp3";
            if (!CheckingUsefully())
            {
                Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
                yield break;
            }
            string fileName = Application.persistentDataPath + "\\words123.mp3";
            byte[] body = System.IO.File.ReadAllBytes(fileName);
            // byte[] body = GameUtil.SafeReadAllByte(fileName);
            UnityWebRequest req = UnityWebRequest.Put("http://127.0.0.1:6080/upload", body);
            yield return req.SendWebRequest();//解决请求时卡顿，解放线程
           // Debug.Log(req.downloadHandler.text);
            if (result != null)
                result(req.downloadHandler.text);
            yield break;

        }
        public static IEnumerator getpointsRanking(string token, int mobile, int game_id, Action<string> result)
        {
            if (!CheckingUsefully())
            {
                Debug.Log("DLL已超过有效期,请联系作者QQ:764521788");
                yield break;
            }
            Debug.Log("发送回复");
            //UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/uploadData");
            UnityWebRequest req = UnityWebRequest.Get("http://127.0.0.1:6080/uploadData?uname=black&upwd=123456");
            yield return req.SendWebRequest();//解决请求时卡顿，解放线程

            Debug.Log("等待回复");
            Debug.Log(req.downloadHandler.text);
            if (result != null)
                result(req.downloadHandler.text);
        }

        private static bool CheckingUsefully()
        {

            Debug.Log(DateTime.Now.ToString("yyMMdd"));
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
