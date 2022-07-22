using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// FSM控制器
/// 玩家，怪物这样角色
/// </summary>
public abstract class FSMcontroller<T> : MonoBehaviour {
	//当前状态
	public T CurrentState;
	//当前状态对象
	protected StateBase<T> Currentobj;
	//对象池，存放全部状态对象
	private Dictionary<T,StateBase<T>> stateDic = new Dictionary<T, StateBase<T>>();
	/// <summary>
	/// 修改状态
	/// </summary>
	public void Changestate<K>(T newState,bool reCurrent =false) where K : StateBase<T>, new()//约束K必须继承了StateBase<T>,且是可以new(实例化)的
	{
		//如果新状态与当前状态一致同时 无需刷新状态 则 什么都不做
		if (newState .Equals(CurrentState) && !reCurrent) return;
		//如果当前状态存在则执行其并退出状态改变判断
		if (Currentobj != null) Currentobj.OnExit();

		//基于新状态的枚举 获得一个 新的状态对象
		Currentobj = GetStateObj<K>(newState);
		Currentobj.OnEnter();

    }
	/// <summary>
	/// 获取状态对象
	/// 你给我一个枚举，我返回一个和这个枚举同名的类型对象
	/// 保证不会返回null
	/// </summary>
	/// <param name="stateType"></param>
	/// <returns></returns>
	private StateBase<T> GetStateObj<K>(T stateType) where K : StateBase<T>,new()
	{
		if (stateDic.ContainsKey(stateType)) return stateDic[stateType];

		////看看库存有没有
  //      for (int i = 0; i < stateList.Count; i++)
  //      {//如果类型一致就可以使用
		//	if (stateList[i].StateType == stateType) return stateList[i];
  //      }
		//库里没有，实例化一个并返回（此处没用到反射,反射性能消耗大）
		StateBase<T> state = new K() ;
		state.Init(this,stateType);
		stateDic.Add(stateType, state);
		return state;
    }
	protected virtual void Update()
    {
		if (Currentobj != null) Currentobj.OnUpdata();
    }
}
