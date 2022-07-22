using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Model : MonoBehaviour
{
    private Player_Controller player;
    private Animator animator;
    bool isOverattack;
    // Start is called before the first frame update
    public void Init(Player_Controller player)
    {
        this.player = player;
        animator = GetComponent<Animator>();
    }
    //更新移动相关参数  
    public void UpdateMovePar(float x,float y )
    {
        animator.SetFloat("左右", x);
        animator.SetFloat("前后", y);
    }
    public void UpdatAttackPar(bool v)
    {

        //animator.SetTrigger("Attack");
        animator.SetBool("Attack1",v);
        //Debug.Log("a");
        
    }
    private void Start()
    {
        AnimationEvent evt = new AnimationEvent();
        // 绑定触发事件后要执行的方法名
        evt.functionName = "OverAttack";
        for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            if (animator.runtimeAnimatorController.animationClips[i].name == "攻击1")
            {
                AnimationClip clip = animator.runtimeAnimatorController.animationClips[i];
                Debug.Log(i);
                // 绑定事件
                clip.AddEvent(evt);
            } 
        }
       
       // AnimationClip clip = animator.runtimeAnimatorController.animationClips.Length;
       
      
    }
    public void OverAttack()
    {
        Debug.Log("as");
       
    }
}
