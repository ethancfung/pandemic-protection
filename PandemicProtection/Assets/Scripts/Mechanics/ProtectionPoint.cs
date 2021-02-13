using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectionPoint : MonoBehaviour
{    
    /*public static ProtectionPoint instance;

    void Start() {
        if (instance == null){
            instance = this;
        }
    }*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("Player"))
        {
            PointManager.instance.UpdatePoints(1);
        }
    }
}
