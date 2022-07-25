using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Observe_Player : MonoBehaviour
{/// <summary>
/// 通过委托实现观察者模式,让所有人订阅观察者以达到广播的效果
/// </summary>
    public int HP = 3;
    public static event Action PlayerIsDeadDelegate;
    private void OnDisable()
    {
        PlayerIsDeadDelegate?.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillMySelf();
    }
    void KillMySelf()
    {
        if (HP>0)
        {
            HP--;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
