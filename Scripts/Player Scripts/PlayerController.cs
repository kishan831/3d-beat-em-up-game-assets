using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterAnimation characterAnimation;
    private Rigidbody rb;

    public float WalkSpeed = 2f;
    public float zSpeed = 1.5f;

    private float rotation_y = -90f;


    void Awake() {
       characterAnimation = GetComponentInChildren<CharacterAnimation>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
        
    }

    void FixedUpdate() {
         Movement();
    }

    void Movement() {

        rb.velocity = new Vector3 (Input.GetAxisRaw("Horizontal") * (WalkSpeed),
        rb.velocity.y,
        Input.GetAxisRaw("Vertical") * (zSpeed));
    }

    void RotatePlayer() {

        if(Input.GetAxisRaw("Horizontal") > 0) {
            transform.rotation = Quaternion.Euler(0f,Mathf.Abs(rotation_y),0f);
        }

        else if(Input.GetAxisRaw("Horizontal") < 0) {
            transform.rotation = Quaternion.Euler(0f,-Mathf.Abs(rotation_y),0f);
        }
    }

    void AnimatePlayerWalk() {

        if(Input.GetAxisRaw("Horizontal") != 0  || Input.GetAxisRaw("Vertical") != 0) {
             characterAnimation.Walk(true);
        }

        else {
            characterAnimation.Walk(false);
        }
            
     }

}
