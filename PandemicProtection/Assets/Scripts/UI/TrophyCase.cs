using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrophyCase : MonoBehaviour
{
    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;

    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Groceries" + "High"))
        {
            score1.text = PlayerPrefs.GetInt("Groceries" + "High").ToString();
        }
        else
        {
            score1.text = 0.ToString();
        }

        if(PlayerPrefs.HasKey("Bank Appointment" + "High"))
        {
            score2.text = PlayerPrefs.GetInt("Bank Appointment" + "High").ToString();
        }
        else
        {
            score2.text = 0.ToString();
        }

        if(PlayerPrefs.HasKey("Annual Checkup" + "High"))
        {
            score3.text = PlayerPrefs.GetInt("Bank Appointment" + "High").ToString();
        }
        else
        {
            score3.text = 0.ToString();
        }
        exit.onClick.AddListener(TaskOnClick);     
    }

    void TaskOnClick()
    {
        LevelLoader.instance.LoadNextLevel("Home");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
