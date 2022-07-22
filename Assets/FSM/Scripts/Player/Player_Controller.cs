using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlayerState
{
	Player_None,
	Player_Move,
	Player_Attack
}
public class Player_Controller : FSMcontroller<PlayerState>
{

	//public override T CurrentState { get { return playerState; } set { playerState = (PlayerState)value; } }
	//private PlayerState playerState;
	public Player_Input input { get; private set; }
	public new Player_Audio audio { get; private set; }//new是为了避免同名
	public Player_Model model { get; private set; }

	public CharacterController characterController { get;private set; }
	// Use this for initialization
	private void Start () {


		input = new Player_Input();
		audio = new Player_Audio(GetComponent<AudioSource>());
		model =transform.Find("Model").GetComponent<Player_Model>();
		model.Init(this);
		characterController = GetComponent<CharacterController>();
		//默认是移动状态
		Changestate<Player_Move>(PlayerState.Player_Move);
		//Changestate<Player_Attack>(PlayerState.Player_Attack);
	}
    protected override void Update()
    {
        base.Update();
        if (input.GetAttackKey())
        {
			Changestate<Player_Attack>(PlayerState.Player_Attack);
		}
        else if (input.Horizontal!=0|| input.Vertical!=0)
        {
			Changestate<Player_Move>(PlayerState.Player_Move);
		}
    }

	public void OverAttack(/*float f,int i,string s,object obj*/)
	{
		Debug.Log("as");

	}

}
