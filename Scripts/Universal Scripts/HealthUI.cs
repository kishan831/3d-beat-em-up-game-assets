using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private Image health_ui;

    void Awake() {
        health_ui = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();

    } //Awake

    public void DisplayHealth(float value) {
       value /= 100;

       if(value < 0) 
          value = 0f;

    } //DisplayHealth

}//class


