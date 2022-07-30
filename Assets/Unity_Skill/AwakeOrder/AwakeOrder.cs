using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeOrder : MonoBehaviour
{
    //控制脚本初始化的顺序

    //方法1:声明在加载场景前触发!
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoad()
    {
        Debug.Log("声明在加载场景前触发!");
    }
   
    //方法2:Editor-ProjectSetting-Script Excute Order中可以设置脚本执行优先级
}
