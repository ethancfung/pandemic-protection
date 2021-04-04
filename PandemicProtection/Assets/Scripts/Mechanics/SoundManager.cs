using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip coinSound, hitSound, winSound, loseSound, exitSound, buySound, buttonSound, jumpSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        coinSound = Resources.Load<AudioClip>("Sounds/Collect_Point_00");
        hitSound = Resources.Load<AudioClip>("Sounds/Hit_01");
        winSound = Resources.Load<AudioClip>("Sounds/Jingle_Achievement_00");
        loseSound = Resources.Load<AudioClip>("Sounds/Jingle_Lose_01");
        exitSound = Resources.Load<AudioClip>("Sounds/Menu_Navigate_03");
        buySound = Resources.Load<AudioClip>("Sounds/Collect_Point_01");
        buttonSound = Resources.Load<AudioClip>("Sounds/Shoot_01");
        jumpSound = Resources.Load<AudioClip>("Sounds/Jump_03");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
            case "lose":
                audioSrc.PlayOneShot(loseSound);
                break;
            case "exit":
                audioSrc.PlayOneShot(exitSound);
                break;
            case "buy":
                audioSrc.PlayOneShot(buySound);
                break;
            case "button":
                audioSrc.PlayOneShot(buttonSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
        }
    }
}
