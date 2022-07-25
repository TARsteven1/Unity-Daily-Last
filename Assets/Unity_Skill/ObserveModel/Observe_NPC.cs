using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observe_NPC : MonoBehaviour
{
    private void OnEnable()
    {
        Observe_Player.PlayerIsDeadDelegate += MoveTowardTop;
    }
    void MoveTowardTop()
    {
        transform.Translate(Vector3.up);
    }

    private void OnDisable()
    {
        Observe_Player.PlayerIsDeadDelegate -= MoveTowardTop;
    }
}
