using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
[Hotfix]
public class Cube : MonoBehaviour
{
    public Rigidbody Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [LuaCallCSharp]
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Rigidbody.AddForce(Vector3.up * 500);
        }
    }

}
