using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input  {
	//自定义keycode
	private KeyCode runKeyCode = KeyCode.LeftShift;
	private KeyCode attackKeyCode = KeyCode.J;
	public float Horizontal { get {return Input.GetAxis("Horizontal"); } }
	public float Vertical { get { return Input.GetAxis("Vertical"); } }
	//按键持续按下状态
	public bool GetKey(KeyCode key)
    {
		return Input.GetKey(key);
    }
	//按下瞬间
	public bool GetKeyDown(KeyCode key)
    {
		return Input.GetKeyDown(key);

	}

	public bool GetRunKey()
    {
		return GetKey(runKeyCode);

	}
	public bool GetAttackKey()
	{
		return GetKey(attackKeyCode);

	}
	//public bool GetMoveKey()
 //   {
	//	return GetKey(Input.GetAxis("Vertical"));

	//}
}
