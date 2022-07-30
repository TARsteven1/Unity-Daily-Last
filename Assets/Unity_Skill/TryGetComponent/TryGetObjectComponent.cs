using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryGetObjectComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //代替GetComponent方法,以免找不到组件
        if (other.TryGetComponent<TurnDestory>(out TurnDestory turnDestory)) turnDestory.TurnDestroy();
        //if (other.tag=="XXX")
        //{
        //    other.GetComponent<TurnDestory>().TurnDestroy();
        //}
    }
}
