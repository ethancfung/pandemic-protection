using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenu : MonoBehaviour
{
    public static bool SelectionIsOpen;

    public GameObject selectionUI;

    public static SelectionMenu instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        CloseMenu();
    }

    public void OpenMenu()
    {
        selectionUI.SetActive(true);
        SelectionIsOpen = true;
    }

    public void CloseMenu()
    {
        SoundManager.PlaySound("exit");// also makes a sound everytime the house is pulled up
        selectionUI.SetActive(false);
        SelectionIsOpen = false;
    }
}
