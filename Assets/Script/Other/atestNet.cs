using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//using Newtonsoft.Json;
using LitJson;
using NetWorkingAPI;
public class atestNet : MonoBehaviour
{
    public Text text;
    [Header("数据")]
    [SerializeField]
    string Loginpath;
    [SerializeField]
    string UpLoadpath;
    [SerializeField]
    string DownLoadpath;

    [SerializeField]
    string mobile_code;
    [SerializeField]
    string game_id;
    [SerializeField]
    string device;

    string mobile;
    string token;
    string ponitsNum;


    [Space(5)]
    [Header("UI")]
    [SerializeField]
    private Text moble;
    [SerializeField]
    private Text points;
    [SerializeField]
    private Text TipsText;
    [SerializeField]
    private GameObject Tips;    
    [SerializeField]
    private GameObject RankingSlot_Prefab;    
    [SerializeField]
    private Transform RankingSlotParent;
    private void Awake()
    {
        JsonMapper.RegisterImporter<int, string>((int value) =>
        {
            return value.ToString();
        });
    }
    [ContextMenu("33")]
    public void Login()
    {
         //Loginpath = "http://cmcc.dwtv.tv/user/login";
         mobile = moble.text;
        //mobile_code = "1";
        //game_id = "01";
       // device = "1";

        JsonData data = new JsonData();//写入json格式的数据
        data["mobile_code"] = mobile_code;
        data["mobile"] = mobile;
        data["game_id"] = game_id;
        data["device"] = device;
        byte[] postBytes = System.Text.Encoding.Default.GetBytes(data.ToJson());//把json格式的字符串转化成数组

        StartCoroutine(PointsHandler.UserLogin(Loginpath,postBytes, (result) =>
        {
           // Debug.Log("Result:" + result);
           // string ret = result;
           // text.text = ret;
            GetJsonData(result);

        }));
    }
    void GetJsonData(string data)
    {
        // RootObject rootData = JsonConvert.DeserializeObject<RootObject>(data);

        RootObject rootData = JsonMapper.ToObject<RootObject>(data);
        //Debug.Log(rootData.ToString());
        if (data != null || data != "")
        {
            if (rootData.code == "0")
            {

                token = rootData.result.token;
                //登陆成功
            }
            else
            {
                ReadErroCade(rootData.code);
            }
        }
    }
    void GetJson2Data(string data)
    {
        //UpDatecallback rootData = JsonConvert.DeserializeObject<UpDatecallback>(data);
        UpDatecallback rootData = JsonMapper.ToObject<UpDatecallback>(data);
        if (data != null || data != "")
        {
            if (rootData.code == "0")
            {
               // Debug.Log("Update Suc"); 
                ReadErroCade("Update Suc");

            }
            else
            {
                ReadErroCade(rootData.code);
            }
        }
    }
    [ContextMenu("44")]
    public void UpLoadData()
    {
        //UpLoadpath = "http://cmcc.dwtv.tv/user/uploadPoints";
        //mobile = "13193186112";
        ////token = "1";
        //game_id = "01";
        //device = "1";
        ponitsNum = points.text;
        JsonData data = new JsonData();//写入json格式的数据
        data["token"] = token;
        data["mobile"] = mobile;
        data["game_id"] = game_id;
        data["points"] = ponitsNum;
        Debug.Log(data.ToString());
        byte[] postBytes = System.Text.Encoding.Default.GetBytes(data.ToJson());//把json格式的字符串转化成数组

        StartCoroutine(PointsHandler.uploadPoints(UpLoadpath, postBytes, (result) =>
        {
            GetJson2Data(result);

        }));
    }
    [ContextMenu("55")]
    public void GetPointsRankingData()
    {
        //DownLoadpath = "http://cmcc.dwtv.tv/user/pointsRanking";
        //mobile = "18877985357";
        //game_id = "01";
        StartCoroutine(PointsHandler.getpointsRanking(DownLoadpath, token, mobile, game_id,(result) =>
        {
            // Debug.Log("Result:" + result);
            // string ret = result;
            GetJson3Data(result);
        }));
    }
    void GetJson3Data(string data)
    {
        //DownLoadcallback rootData = JsonConvert.DeserializeObject<DownLoadcallback>(data);
        DownLoadcallback rootData = JsonMapper.ToObject<DownLoadcallback>(data);
        if (data != null || data != "")
        {
            if (rootData.code == "0")
            {
                SpawnRankingSolt(rootData.result);
            }
            else
            {
                ReadErroCade(rootData.code);
            }
        }
    }
    public void ReadErroCade(string erro)
    {
        Tips.SetActive(true);
       
        switch (erro)
        {
            case "3004":
                TipsText.text = "Token失效";
                break;
            case "11006":
                TipsText.text = "token不能为空";
                break;
            case "11000":
                TipsText.text = "手机号不能为空";
                break;
            case "11002":
                TipsText.text = "游戏id不能为空";
                break;
            case "11007":
                TipsText.text = "鉴权失败，请重新登录";
                break;
            case "11008":
                TipsText.text = "token无效，请重新登录";
                break;
            case "11005":
                TipsText.text = "数据不存在";
                break;
            case "11004":
                TipsText.text = "您的订购已过期，请重新续费";
                break;             
            case "11003":
                TipsText.text = "手机号验证码不能为空";
                break;            
            case "11012":
                TipsText.text = "积分值不能为空";
                break;
            case "Update Suc":
                TipsText.text = "积分上传成功!";
                break;
            default:
                TipsText.text = "未知错误"+ erro;
                break;
        }
    }
    public void SpawnRankingSolt(List<RankingData> result)
    {
        for (int i = 0; i < result.Count; i++)
        {
           GameObject gameObject= Instantiate(RankingSlot_Prefab, RankingSlotParent);
            string tempStr = result[i].mobile;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();
            gameObject.transform.GetChild(1).GetComponent<Text>().text = tempStr.Substring(0, 3)+"*****"+ tempStr.Substring(tempStr.Length - 4);
            gameObject.transform.GetChild(2).GetComponent<Text>().text = result[i].points;

        }
    }
}
public class Result
{
    public string mobile { get; set; }
    public string token { get; set; }
}

public class RootObject
{
    public string code { get; set; }
    public string msg { get; set; }
    public Result result { get; set; }
    public string time { get; set; }
}
public class UpDatecallback
{
    public string code { get; set; }
    public string msg { get; set; }
    public string result { get; set; }
    public string time { get; set; }
}
public class RankingData
{
    public string id { get; set; }
    public string created_at { get; set; }
    public string deleted_at { get; set; }
    public string updated_at { get; set; }
    public string mobile { get; set; }
    public string game_id { get; set; }
    public string game_name { get; set; }
    public string points { get; set; }
    public string remark { get; set; }
}

public class DownLoadcallback
{
    public string code { get; set; }
    public string msg { get; set; }
    public List<RankingData> result { get; set; }
    public string time { get; set; }
}
