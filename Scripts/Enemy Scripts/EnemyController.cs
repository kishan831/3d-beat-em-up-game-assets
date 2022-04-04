using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private CharacterAnimation EnemyAnim;
    private Rigidbody rb;
    public float speed = 5f;
    public Transform PlayerTarget;
    public float Attack_Distance = 1f;
    private float Chase_Player_After_Attack = 1f;

    public float current_Attack_time;
    private float default_Attack_time = 2f;

    private bool followPlayer,AttackPlayer;

    void Awake() {
        EnemyAnim = GetComponentInChildren<CharacterAnimation>();
        rb = GetComponent<Rigidbody>();

        PlayerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start() {
        followPlayer = true;
        current_Attack_time = default_Attack_time;
    }


    void Update() {
      Attack();

    }

    void FixedUpdate() {
        FollowTarget();
    }

    void FollowTarget() {
       
       //if not following player
       if(!followPlayer) {
           return;
       }

       if(Vector3.Distance(transform.position, PlayerTarget.position) > Attack_Distance) {
         
         transform.LookAt(PlayerTarget);
         rb.velocity = transform.forward * speed;

         if(rb.velocity.sqrMagnitude != 0) {
             EnemyAnim.Walk(true);
         }

       }

         else if(Vector3.Distance(transform.position,PlayerTarget.position) <= Attack_Distance) {
            
            rb.velocity = Vector3.zero;
            EnemyAnim.Walk(false);

            followPlayer = false;
            AttackPlayer = true;

         }

    } //follow player

    void Attack() {
           
           //if not attacking on player
           //exit function
          if(!AttackPlayer) {
              return;
          }
          
          current_Attack_time += Time.deltaTime;

          if(current_Attack_time > default_Attack_time) {

              EnemyAnim.EnemyAttack(Random.Range(0,3));

              current_Attack_time = 1f;
          }
          
          if(Vector3.Distance(transform.position,PlayerTarget.position) > (Attack_Distance + Chase_Player_After_Attack)) {
             
             AttackPlayer = false;
             followPlayer = true;

          } 

    } //attack

} //class
