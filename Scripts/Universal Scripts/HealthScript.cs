using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour
{

    [SerializeField] public float health = 100f;

    private CharacterAnimation animationScripts;

    private EnemyController enemyController;

    private HealthUI healthUI;

    private bool characterDied;

    public bool IsPlayer;


    void Awake() {
        animationScripts = GetComponentInChildren<CharacterAnimation>();

        if(IsPlayer) {

        healthUI = GetComponent<HealthUI>();

        }
    }


    public void ApplyDamage(float damage, bool knockdown) {

        if(characterDied) {
            return;
        }

        health -= damage;

        //display health UI
        if(IsPlayer)
        healthUI.DisplayHealth(health);



        if(health <= 0f) {
            animationScripts.Death();
            characterDied = true;
             

            //if player deactivated enemy scripts.
            if(IsPlayer) {

                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false;

            }
            return;
        }

        if(!IsPlayer) {

            if(knockdown) {

                if(Random.Range(0,2) > 0) {
                    animationScripts.KnockDown(); 
                    
                
                }

                else{
                    
                    if(Random.Range(0,1) > 1) {
                        animationScripts.Hit();
                    }
                }
            }
        }


    } //Apply Damage
 







}//class
