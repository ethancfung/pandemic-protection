using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelStats : MonoBehaviour
{

    public TextMeshProUGUI levelName;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pointsText;
    public Image highScoreImg;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalScoreText;
    private string level;
    private int score;
    private float time;
    private int points;
    private int remainingHealth;
    private bool newHighScore;
    private int finalScore;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetString("Level");
        score = PlayerPrefs.GetInt("Score");
        time = PlayerPrefs.GetFloat("Time");
        points = PlayerPrefs.GetInt("Points");
        remainingHealth = PlayerPrefs.GetInt("Health");

        levelName.text = "Completed errand: " + level;
        scoreText.text = "Safety Score: " + score.ToString();
        timeText.text = "Time: " + time.ToString("F1");
        pointsText.text = "x " + points.ToString();
        //Debug.Log("OLD HIGH SCORE: " + PlayerPrefs.GetInt(level + "High"));

        finalScore = calculateFinalScore();
        finalScoreText.text = "Final Score: " + finalScore.ToString();
        
        newHighScore = (!PlayerPrefs.HasKey(level + "High") || (finalScore > PlayerPrefs.GetInt(level + "High")));
        if (newHighScore)
        {
            highScoreImg.enabled = true;
            highScoreText.enabled = true;
        }else
        {
            highScoreImg.enabled = false;
            highScoreText.enabled = false;
        }
    }

    // final score calculation based on safety score, time, and remaining health
    private int calculateFinalScore()
    {
        int subtraction = (int) (500 * time);

        if (subtraction > 45000)
        {
            subtraction = 45000; // cap
        } 

        int healthBonus = 0;
        if (remainingHealth >= 100)
        {
            healthBonus = 5;
        }else if (remainingHealth > 75)
        {
            healthBonus = 3;
        }else if (remainingHealth > 50)
        {
            healthBonus = 2;
        }else if (remainingHealth > 25)
        {
            healthBonus = 1;
        }else
        {
            healthBonus = -1;
        }

        int final = score - subtraction + healthBonus * 10000;

        return final;

    }

    public void SaveStats()
    {
        SoundManager.PlaySound("exit");
        // new high score
        if (newHighScore)
        {
            PlayerPrefs.SetInt(level + "High", finalScore);
        }

        if (PlayerPrefs.HasKey("Total Points"))
        {
            PlayerPrefs.SetInt("Total Points", PlayerPrefs.GetInt("Total Points") + points);
        }else 
        {
            PlayerPrefs.SetInt("Total Points", points);
        }

        // clear
        PlayerPrefs.DeleteKey("Level");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("Points");
    }

    private void OnApplicationQuit()
    {
        SaveStats(); // save stats if they quit game mode
    }

}
