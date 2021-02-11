using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafetyScore : MonoBehaviour
{
    public Text Score;
    public int modifier;
    private int currScore;
    private int gameStartTime;

    // Start is called before the first frame update
    void Start()
    {
        Score = GetComponent<Text>();
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
            /*
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
            }*/
            currScore += modifier;
            Score.text = currScore.ToString();
            gameStartTime = (int)Time.time;

        }
    }
}
