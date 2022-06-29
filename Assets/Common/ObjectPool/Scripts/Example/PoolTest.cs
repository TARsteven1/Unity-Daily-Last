using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    //申明一个对象池
    public BasePool<UITest> basePool;

    public UITest uITest;
    private Vector3 pos = Vector3.zero;

    private void Start()
    {
        //对象池实例化
        basePool = new BasePool<UITest>(uITest);
    }


    private void Update()
    {
        if (Time.frameCount % 15 == 0)
        {
            //从对象池中获取一个对象
            var obj = basePool.Get();

            obj.transform.SetParent(this.transform, false);
            pos.x = Random.Range(-375, 375);
            pos.y = Random.Range(-750, 750);
            obj.transform.localPosition = pos;
            StartCoroutine(TestPut(obj, 0.5f));
        }
    }
    
    
    private IEnumerator TestPut(UITest go, float t)
    {
        yield return new WaitForSeconds(t);
        //将回收到对象池中
        basePool.Put(go);
    }
}
