using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This Scripts used for when our player is attacking on the enemy the first place, hit any on the enemy body part it will detect collision and 
//Generates Hit Effects.
public class AttackUniversal : MonoBehaviour
{

    public LayerMask collisionlayer;
    public float redius = 1f;
    public float damage = 2f;
    public bool Isplayer,IsEnemy;

    public GameObject HIT_FX_PREFABS;
 
    void Update()
    {
        DetectCollision();
    }

    void DetectCollision() {
       Collider[] hit = Physics.OverlapSphere(transform.position ,1f, collisionlayer);

       if(hit.Length > 0) {


           if(Isplayer) {

           Vector3  Hit_fx = hit[0].transform.position;
           Hit_fx.y += 1.3f;

           if(hit[0].transform.forward.x > 0) {
               Hit_fx.x += .03f;
           }

           else if(hit[0].transform.forward.x < 0) {
               Hit_fx.x -= 0.3f;
           }

           Instantiate(HIT_FX_PREFABS,Hit_fx,Quaternion.identity);


           if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG)) {
               hit[0].GetComponent<HealthScript>().ApplyDamage(damage,true);
           }

           else {
               hit[0].GetComponent<HealthScript>().ApplyDamage(damage,false);
           }

           }

           gameObject.SetActive(false);

       }

    }//Detect Collision

} //class
