using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelStats : MonoBehaviour
{

    public TextMeshProUGUI levelName;
    public TextMeshProUGUI score;
    public TextMeshProUGUI time;
    public TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {
        levelName.text = "Completed errand: " + PlayerPrefs.GetString("Level");
        score.text = "Safety Score: " + PlayerPrefs.GetInt("Score").ToString();
        time.text = "Time: " + PlayerPrefs.GetFloat("Time").ToString("F1");
        points.text = "x " + PlayerPrefs.GetInt("Points").ToString();
    }

    void SaveStats()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
