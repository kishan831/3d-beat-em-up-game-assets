using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateScripts : MonoBehaviour
{
    //Deeactivating the Hit effect
    public float timer = 2f;

    void Start()
    {
        Invoke("DeactiveAftertime",timer);
    }

    
    void DeactiveAftertime()
    {
        gameObject.SetActive(false);
    }
}
