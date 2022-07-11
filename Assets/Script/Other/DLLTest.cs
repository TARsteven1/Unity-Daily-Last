using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetWorkingAPI;

public class DLLTest : MonoBehaviour
{
    //string a = "a";
    // Start is called before the first frame update
    void Start()
    {
        NetWorkingPoints.TestDll("1");
        // Debug.Log(NetWorkingAPI.NetWorkingAPI.TestDll("1"));
        StartCoroutine(NetWorkingPoints.uploadPoints("1",1,1,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
