using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState {
    None,PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}
public class PlayerAttack : MonoBehaviour {

     private CharacterAnimation characterAnimation;
     private bool activateTimerToReset;
     private float default_Combo_Timer = .4f;

      private float current_Combo_Timer;

      private ComboState current_Combo_State;
    
    void Start() {

        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.None;
    }

    void Awake() {
       characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }


    void Update() {

        ComboAttack();
        ResetComboState();
        
    }

    void ComboAttack() {
       
       if(Input.GetKeyDown(KeyCode.Z)) {
          
          if(current_Combo_State == ComboState.PUNCH3 || current_Combo_State == ComboState.KICK1 || current_Combo_State == ComboState.KICK2)
          return;

           current_Combo_State++;
           activateTimerToReset = true;
           current_Combo_Timer = default_Combo_Timer;

           if(current_Combo_State == ComboState.PUNCH1) {
               characterAnimation.PUNCH1();
           }

            if(current_Combo_State == ComboState.PUNCH2) {
               characterAnimation.PUNCH2();
            }

            if(current_Combo_State == ComboState.PUNCH3) {
               characterAnimation.PUNCH3();
            }

       } //if punch

        if(Input.GetKeyDown(KeyCode.X)) {


           //if current combo is puunch 3 or kick 2 then exit.
           if(current_Combo_State == ComboState.KICK2 || current_Combo_State == ComboState.PUNCH3)
           return;

            //if currest state is like this then change to combo.
            if(current_Combo_State == ComboState.None || current_Combo_State == ComboState.PUNCH1 || current_Combo_State == ComboState.PUNCH2) {
                current_Combo_State = ComboState.KICK1;
            }


            else if(current_Combo_State == ComboState.KICK1) {
               current_Combo_State++;

            }
             activateTimerToReset = true;
             current_Combo_Timer = default_Combo_Timer;



             if(current_Combo_State == ComboState.KICK1) {
                characterAnimation.KICK1();
             }

            if(current_Combo_State == ComboState.KICK2) {
                characterAnimation.KICK2();
             }


       }
    }//if kick

    void ResetComboState() {
        if(activateTimerToReset) {
            current_Combo_Timer -= Time.deltaTime;

            if(current_Combo_Timer <= 0f) {
                current_Combo_State = ComboState.None;
                activateTimerToReset = false;

                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }
}
