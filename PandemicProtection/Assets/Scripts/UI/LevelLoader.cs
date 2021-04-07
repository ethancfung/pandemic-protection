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

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        SocialDistance.withinRange = false;
        if (sceneName.Equals("next")) // load next level in sequence
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else // load specified scene
        {
            StartCoroutine(LoadLevel(sceneName));
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

    IEnumerator LoadLevel(string sceneName)
    {

        // Play animation
        transition.SetTrigger("Start");

        
        if (sceneName.Equals("GameOver"))
        {
            SoundManager.PlaySound("lose");
            yield return new WaitForSeconds(2f);
        }   

        // wait
        yield return new WaitForSeconds(transitionTime);
        

        // load scene
        SceneManager.LoadScene(sceneName);
    }
}
