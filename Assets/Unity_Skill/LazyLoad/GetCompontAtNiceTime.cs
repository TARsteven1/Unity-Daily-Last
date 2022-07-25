using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCompontAtNiceTime : MonoBehaviour
{
    SphereCollider _sphereCollider;
    public LogOutPut logOutPut;
    string temp;
    SphereCollider sphereCollider//在需要的时候初始化,给他人调用
    {
        get
        {
            if (_sphereCollider==null)
            {
                _sphereCollider = GetComponentInChildren<SphereCollider>();
            }
            return _sphereCollider;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DebugLog.Log(logOutPut.outPut_text.text);//调用他人的获取器
    }
    public float GetColliderRadius()//获取器,供他人调用
    {
        return sphereCollider.radius;
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
