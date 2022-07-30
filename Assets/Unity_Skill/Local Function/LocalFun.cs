using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalFun : MonoBehaviour
{
    /// <summary>
    /// 本地方法,可以放在方法内的方法,可以方便传值,但存在闭包的问题
    /// </summary>
  void TestFun()
    {
        int a=1;
        int b=2;

        a = AddNum();

        int AddNum()
        {
            return a + b;
        }
    }
}
