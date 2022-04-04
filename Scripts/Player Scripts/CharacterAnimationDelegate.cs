using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<Summary> for checcking the player is attacking with its hand or leg and then after the Hit effect so we will automatically deleted itself 
//by DeactivatedScripts.

public class CharacterAnimationDelegate : MonoBehaviour  {

    public GameObject left_Arm_Attack_Point,right_Arm_Attack_point,left_Leg_Attack_point,Right_Leg_Attack_Point;


    public float Stand_up_timer = 2f;

    private CharacterAnimation animationScripts;
    private AudioSource audioSource;

    [SerializeField] private AudioClip whoose_Sound,fall_sound,ground_Hit_Sound,Dead_Sound;

    private EnemyController enemymovement;

    void Awake() {
      animationScripts = GetComponent<CharacterAnimation>();
      audioSource = GetComponent<AudioSource>();

      if(gameObject.CompareTag(Tags.ENEMY_TAG)) {
        enemymovement = GetComponentInParent<EnemyController>();
      }
    }

    void left_Arm_Attack_On() {
        left_Arm_Attack_Point.SetActive(true);

    }

      void left_Arm_Attack_Off() {

        if(left_Arm_Attack_Point.activeInHierarchy) {
        left_Arm_Attack_Point.SetActive(false);
          }
    }

        void right_Arm_Attack_On() {
        right_Arm_Attack_point.SetActive(true);

    }

      void right_Arm_Attack_Off() {

        if(right_Arm_Attack_point.activeInHierarchy) {
        right_Arm_Attack_point.SetActive(false);
          }
    }

    void left_Leg_Attack_On() {
      left_Leg_Attack_point.SetActive(true);
    }

    void left_Leg_Attack_Off() {
        if(left_Leg_Attack_point.activeInHierarchy) {
            left_Leg_Attack_point.SetActive(false);
        }
    }

       void right_Leg_Attack_On() {
      Right_Leg_Attack_Point.SetActive(true);
    }

    void right_Leg_Attack_Off() {
        if(Right_Leg_Attack_Point.activeInHierarchy) {
            Right_Leg_Attack_Point.SetActive(false);
        }
    }

    void TagLeft_Arm() {
      left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeft_Arm() {
      left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

        void TagLeft_Leg() {
      left_Leg_Attack_point.tag = Tags.LEFT_LEG_TAG;
    }

    void UnTagLeft_Leg() {
      left_Leg_Attack_point.tag = Tags.UNTAGGED_TAG;
    }

    void EnemyStandUp() {
       StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime() {
      yield return new WaitForSeconds(Stand_up_timer);
      animationScripts.Standup();
    }

    public void Attck_FX_Sound() {
      audioSource.volume = .2f;
      audioSource.clip = whoose_Sound;
      audioSource.Play();
    }

    void CharacterDiedSound() {
         audioSource.volume = 1f;
      audioSource.clip = Dead_Sound;
      audioSource.Play();
    }

    void EnemyKnockDownSound() {
      audioSource.clip = fall_sound;
      audioSource.Play();
    }

    void Enemy_Hit_Ground() {
      audioSource.clip = ground_Hit_Sound;
      audioSource.Play();
    }

    void DisableMovement() {
      enemymovement.enabled = false;
    }

    void EnableMovement() {
      enemymovement.enabled = true;
    }

    void CharacterDied(){
      Invoke("DeactivateGameObjects", 2f);
    }

    void DeactivateGameObjects() {
      EnemyManager.instance.SpawnEnemy();

      gameObject.SetActive(false);
    }


}//class
