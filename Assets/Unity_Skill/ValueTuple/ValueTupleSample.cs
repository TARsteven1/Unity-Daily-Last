using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTupleSample : MonoBehaviour
{
    //！！元祖是轻量化的类 值元祖轻量化的结构体！！

    //声明两个值元组
    public (int id, int value) sampleValueTuple;
    public (int , int ) sampleNoNameingValueTuple;

    void Start()
    {
        //不同形式的赋值和转换（只要不是在对象中就不会产生GC）
        sampleValueTuple =new ValueTuple<int, int>(1,1);
        sampleValueTuple = ValueTuple.Create(2, 2);
        sampleValueTuple = (id: 3, value: 3);
        sampleValueTuple = sampleNoNameingValueTuple;

        sampleNoNameingValueTuple.Item1 = 4;
        sampleNoNameingValueTuple.Item2 = 4;

         (int, int) newValueTuple= sampleValueTuple;

        //tuple.Item1 = 0;元组无法直接赋值
        Tuple<int, int> tuple = new Tuple<int, int>(sampleValueTuple.id, sampleNoNameingValueTuple.Item2);
        //值元组转换成元组
        tuple = sampleValueTuple.ToTuple();

        ShowValue(newValueTuple);
    }

    public void ShowValue((int x,int val) valueTuple)
    {
        Debug.Log($"{valueTuple.x} {valueTuple.val}");

    }
}
