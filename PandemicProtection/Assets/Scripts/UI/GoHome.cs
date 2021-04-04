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
            SoundManager.PlaySound("exit");
            LevelLoader.instance.LoadNextLevel("Home"); // go home
        });
    }
}
