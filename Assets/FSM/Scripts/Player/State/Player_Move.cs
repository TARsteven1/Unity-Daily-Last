using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : StateBase<PlayerState>
{
    public Player_Controller player;
    private float runTransition;    
    private float moveSpeed = 9;
    private float rotationSpeed = 90;

    private bool isRun { get {         
            if (player.input.GetRunKey() && player.input.Vertical > 0) moveSpeed = 200f;
            else moveSpeed = 100f;
            return player.input.GetRunKey() && player.input.Vertical > 0; }         }
    public override void Init(FSMcontroller<PlayerState> controller, PlayerState stateType)
    {
        base.Init(controller, stateType);
        player = controller as Player_Controller;
    }

    public override void OnEnter() { }

    public override void OnExit() { }

    public override void OnUpdata()
    {
        float h = player.input.Horizontal;
        float v = player.input.Vertical;
        if (v>=0)
        {
            if (isRun && runTransition < 1) runTransition += Time.deltaTime / 2;
            else if(!isRun&& runTransition > 0) runTransition -= Time.deltaTime / 2;
        }
        else if (runTransition > 0) runTransition -= Time.deltaTime / 2;
    
        Move(h, v+ runTransition);
    }
    private void Move(float h, float v)
    {
        Vector3 dir = new Vector3(0, 0, v);
        //设置一角色为中心进行移动，标准写法
        dir = player.transform.TransformDirection(dir);
       // player.characterController.SimpleMove(dir * Time.deltaTime * moveSpeed);
        //player.characterController.SimpleMove(dir * moveSpeed);
        player.characterController.Move(dir * Time.deltaTime * moveSpeed);
        Vector3 rot = new Vector3(0, h, 0);
        player.transform.Rotate(rot* Time.deltaTime *rotationSpeed);

        player.model.UpdateMovePar(h, v);
    }

}
