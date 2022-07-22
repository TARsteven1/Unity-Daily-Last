using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    /// <summary>
    /// 状态对象基类
    /// 之后所有状态都继承此类
    /// 如：Idle Walk Attack
    /// </summary>
    public abstract class StateBase<T>
    {
    //代表当前状态对象 代表 的枚举状态
    public T StateType;
    //当前的角色控制
   // public FSMcontroller controller;
    //首次实例化时的初始化
    public virtual void Init(FSMcontroller<T> controller ,T stateType)
    {
        //this.controller = controller;
        this.StateType = stateType;
    }
    //进入
    public abstract void OnEnter();

    //更新
    public abstract void OnUpdata();
    //退出
    public abstract void OnExit();

}


