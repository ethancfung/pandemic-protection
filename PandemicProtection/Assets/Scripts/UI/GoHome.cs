using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoHome : MonoBehaviour
{
    public Button triggerBtn;

    public void Start()
    { 
        triggerBtn = GetComponent<Button>();
        triggerBtn.onClick.AddListener(() => {
            LevelLoader.instance.LoadNextLevel(1); // go home
        });
    }
}
