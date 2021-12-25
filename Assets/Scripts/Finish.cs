using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import secene management to change levels
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Audio variable
    private AudioSource finishSound;

    // Need a condition so when finish flag is touched, we prevent character triggering flag sound multiple times
    private bool flagTouch = false;

    // Need a variable to store bacnk value before I update
    private int poolPineapples;
    
    private void Start()
    {
        // getting the audio sound component
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // detect collision - Finish
        if (collision.gameObject.name == "Player" && !flagTouch)
        {
            finishSound.Play();
            // Set to true so the condtion fails if player runs into flag multiple times (stops sounds running more than once)
            flagTouch = true;
            // Upon reaching flag, add what pineapples are in the bank + what pineapples are collected this round
            poolPineapples = PlayerPrefs.GetInt("Pineapples") + PlayerPrefs.GetInt("PineappleBank");
            // Setting new bank total 
            PlayerPrefs.SetInt("PineappleBank", poolPineapples);
            // Cause a delay using invoke before loading new level, in order to play sound
            Invoke("LevelComplete", 1f);
        }
    }

    private void LevelComplete()
    {
        // this takes the current scene which is level 1 at index 0. Add one, making it level 2 and load it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
