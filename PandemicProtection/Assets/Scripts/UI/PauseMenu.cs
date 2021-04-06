﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu: MonoBehaviour
{
    public GameObject pausemenu;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
        isPaused = false;
    }
}
