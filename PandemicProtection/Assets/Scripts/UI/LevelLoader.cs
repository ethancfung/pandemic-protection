using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public Animator transition;
    public float transitionTime = 1f;
    //public Button transitionBtn;
    //public int nextScreen = -1;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }*/
        //Button btn = transitionBtn.GetComponent<Button>();
        //btn.onClick.AddListener(LoadNextLevel);
    }

    public void LoadNextLevel(int nextScreen)
    {
        if (nextScreen == -1) // load next level in sequence
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else // load specified build index
        {
            StartCoroutine(LoadLevel(nextScreen));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(levelIndex);
    }
}
