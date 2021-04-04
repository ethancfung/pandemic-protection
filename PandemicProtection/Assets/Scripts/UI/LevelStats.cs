using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelStats : MonoBehaviour
{

    public TextMeshProUGUI levelName;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pointsText;
    private string level;
    private int score;
    private float time;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetString("Level");
        score = PlayerPrefs.GetInt("Score");
        time = PlayerPrefs.GetFloat("Time");
        points = PlayerPrefs.GetInt("Points");

        levelName.text = "Completed errand: " + level;
        scoreText.text = "Safety Score: " + score.ToString();
        timeText.text = "Time: " + time.ToString("F1");
        pointsText.text = "x " + points.ToString();
    }

    public void SaveStats()
    {
        SoundManager.PlaySound("exit");
        // new high score
        if (score > PlayerPrefs.GetInt(level + "High"))
        {
            PlayerPrefs.SetInt(level + "High", score);
        }

        if (PlayerPrefs.HasKey("Total Points"))
        {
            PlayerPrefs.SetInt("Total Points", PlayerPrefs.GetInt("Total Points") + points);
        }else {
            PlayerPrefs.SetInt("Total Points", points);
        }

        // clear
        PlayerPrefs.DeleteKey("Level");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Time");
        PlayerPrefs.DeleteKey("Points");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
