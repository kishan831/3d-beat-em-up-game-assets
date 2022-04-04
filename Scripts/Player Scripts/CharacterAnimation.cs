using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;


    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool move) {
        anim.SetBool(AnimationTags.MOVEMENT,move);
        
    }

    public void PUNCH1() {
        anim.SetTrigger(AnimationTags.PUNCH1);
    }

       public void PUNCH2() {
        anim.SetTrigger(AnimationTags.PUNCH2);
    }

       public void PUNCH3() {
        anim.SetTrigger(AnimationTags.PUNCH3);
    }

       public void KICK1() {
        anim.SetTrigger(AnimationTags.KICK1_Trigger);
    }

        public void KICK2() {
        anim.SetTrigger(AnimationTags.KICK2_Trigger);
    }

    public void EnemyAttack(int Attack) {
        if(Attack == 0) {
            anim.SetTrigger(AnimationTags.Attack1_Trigger);
        }

        if(Attack == 1) {
            anim.SetTrigger(AnimationTags.Attack2_Trigger);
        }

        if(Attack == 2) {
            anim.SetTrigger(AnimationTags.Attack3_Trigger);
        }
    }  //Enemy Attack


    public void Walk() {
        anim.SetTrigger(AnimationTags.ENEMYWALK_TRIGGER);
    }


    public void PlayIdleAnimation() {
        anim.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown() {
        anim.SetTrigger(AnimationTags.KNOCK_DOWN_Trigger);
    }

      public void Standup() {
        anim.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }

    public void Hit() {
        anim.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death() {
        anim.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }

}  //class
