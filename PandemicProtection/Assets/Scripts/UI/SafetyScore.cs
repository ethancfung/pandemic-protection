﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafetyScore : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public int modifier;
    private int currScore;
    private int gameStartTime;

    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<TextMeshProUGUI>();
        modifier = 1000;
        currScore = 0;

        gameStartTime = (int)Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //change to time.deltatime?
        int minutes = (int)(Time.time / 60);
        if((int)(Time.time - gameStartTime) == minutes + 1)
        { 
            // Debug.Log(modifier);
            if(Player.withinRange == true) 
            {
                modifier -= 100;
            }
            else
            {
                if(modifier < 1000) 
                {
                    modifier += 100;
                }
            }
            currScore += modifier;
            Score.text = "Safety Score: " + currScore.ToString();
            gameStartTime = (int)Time.time;

        }
    }
}