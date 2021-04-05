using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafetyScore : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Mod;
    public int modifier;
    private int currScore;
    private int gameStartTime;
    public static SafetyScore instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        modifier = 1000;
        currScore = 0;
        gameStartTime = (int)Time.timeSinceLevelLoad;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.timeSinceLevelLoad);
        //change to time.deltatime?
        int minutes = (int)(Time.timeSinceLevelLoad / 60);
        if((int)(Time.timeSinceLevelLoad - gameStartTime) == minutes + 1)
        { 
            if(SocialDistance.withinRange == true) 
            {
                modifier -= 100;
                if (modifier <= 0)
                {
                    LevelLoader.instance.LoadNextLevel("GameOver");
                }
            }
            else
            {
                if(modifier < 1000) 
                {
                    modifier += 100;
                }
            }
            currScore += modifier;
            Mod.text = "x" + modifier.ToString();
            Score.text = "Safety Score: " + currScore.ToString();
            gameStartTime = (int)Time.timeSinceLevelLoad;

        }
    }

    public int GetScore()
    {
        return currScore;
    }
}
