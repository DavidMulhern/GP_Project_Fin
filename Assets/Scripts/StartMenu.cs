using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import scene manage
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public int pineappleCount = 0;
    public int pineappleBank = 0;

    public void StartGame()
    {

        // Storing pineapple values in PlayerPrefs
        PlayerPrefs.SetInt("Pineapples", pineappleCount); // HERE
        // Storing pineapple values in PlayerPrefs
        PlayerPrefs.SetInt("PineappleBank", pineappleBank); // HERE

        // Loading new scene on click
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
