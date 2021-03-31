using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public bool hasCollided = false;
    public string labelText = "";
 
    private void OnGUI()
    {
        if(hasCollided ==true)
        {    

            //GUI.Box(Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (Input.GetKeyDown(KeyCode.E)) {        
            //TRANSITION TO STORE SCENE  
            Debug.Log("logging on to PPzon...");
            LevelLoader.instance.LoadNextLevel("Shop");                        
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player") 
        {
            hasCollided = true;
            labelText = "Log onto PPzon? (press E to continue)";
        }
        Debug.Log(labelText);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        hasCollided = false;
    
    }
}
