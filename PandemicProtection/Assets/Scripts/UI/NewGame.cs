using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
