using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug=UnityEngine.Debug;

public static class DebugLog 
{
    [Conditional("ENABLE_DEBUG_LOG")]//在palyersetting中添加SDSymbols(预定义),就可以使下面方法全局生效
  public static void Log(string content)
    {
        Debug.Log(content);
    }
}
public class ConditionLog : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("普通日志");
        DebugLog.Log("使用Log");
    }
}
