using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LogOutPut : MonoBehaviour
{
    public string newMsg;
    public string newMsgStackTrace;
    private StringBuilder builder = new StringBuilder();
    public Text outPut_text;

    ConcurrentQueue<string> vs = new ConcurrentQueue<string>();//线程安全的队列
    private void OnEnable()
    {
        //Application.logMessageReceived +=OnLogMessageReceived;//主线程中调用,线程不安全,可直接调用unity的API
         Application.logMessageReceivedThreaded += OnLogMessageReceived;//其他线程中,线程安全,不能调用unity的API,常用,可在多线程中保持日志
    }
    void OnLogMessageReceived(string condition,string stacktrace,LogType type)
    {
        newMsg = condition;
        newMsgStackTrace = stacktrace;
        vs.Enqueue(newMsg);
    }
    void Add2OutPutShow()
    {
        builder.Append($"{System.Environment.NewLine}");
        builder.Append($"{newMsg}");
        outPut_text.text = builder.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        string result;
        while (vs.TryDequeue(out result))//出队列操作
        {
            builder.Append($"{System.Environment.NewLine}");
            builder.Append($"{result}");
            if (vs.Count==0)
            {
                outPut_text.text = builder.ToString();
            }
        }
        //if (!string.IsNullOrEmpty(newMsg))
        //{
        //    Add2OutPutShow();
        //    newMsg = "";
        //}
    }
    private void OnDisable()
    {
        //Application.logMessageReceived -=OnLogMessageReceived;
        Application.logMessageReceivedThreaded -= OnLogMessageReceived;
    }
}
