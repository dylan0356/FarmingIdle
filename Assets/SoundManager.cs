using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerDeathSound, starSound, turretFire, levelCompleteSound, buttonClickSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        
        playerDeathSound = Resources.Load<AudioClip>("playerDeath");
        starSound = Resources.Load<AudioClip>("starSound");
        turretFire = Resources.Load<AudioClip>("turretFire");
        levelCompleteSound = Resources.Load<AudioClip>("levelComplete");
        buttonClickSound = Resources.Load<AudioClip>("buttonClick");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
            
            switch (clip) {
                case "playerDeath":
                    audioSrc.PlayOneShot(playerDeathSound);
                    break;
                case "star":
                    audioSrc.PlayOneShot(starSound);
                    break;
                case "jump":
                    audioSrc.PlayOneShot(turretFire);
                    break;
                case "levelComplete":
                    audioSrc.PlayOneShot(levelCompleteSound);
                    break;
                case "buttonClick":
                    audioSrc.PlayOneShot(buttonClickSound);
                    break;
            }
    }
}
