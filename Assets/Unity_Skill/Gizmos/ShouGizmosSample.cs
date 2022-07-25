using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouGizmosSample : MonoBehaviour
{
    public float raderRadius;

    private void OnDrawGizmos()//在edit模式下,每一帧执行
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,raderRadius);
    }
    private void OnDrawGizmosSelected()//点选时调用
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raderRadius);
        Gizmos.DrawIcon(transform.position+Vector3.up*3, "Head");
    }
}
