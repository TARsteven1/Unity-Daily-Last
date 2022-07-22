using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : StateBase<PlayerState>
{
    public Player_Controller player;
    private bool isAttacking
    {
        get
        {
            return player.input.GetAttackKey() /*&& player.input.Vertical > 0*/;
        }
    }
    public override void Init(FSMcontroller<PlayerState> controller, PlayerState stateType)
    {

        base.Init(controller, stateType);
        player = controller as Player_Controller;
    }
    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
       
    }

    public override void OnUpdata()
    {
        //if (isAttacking==true)
        //{
        //    Attacking();
        //}
            Attacking(isAttacking);
    }
    void Attacking(bool v)
    {
        
        player.model.UpdatAttackPar(isAttacking);
    }

  
}
