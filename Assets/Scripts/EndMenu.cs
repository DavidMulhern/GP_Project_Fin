using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Import text namespace
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    // Text on screen showing collection tally
    [SerializeField] private Text finalTally;

    private void Start()
    {
        // assigning the text field with the total pineapples collected on load 
        finalTally.text = "Total Pineapples Collected: " + PlayerPrefs.GetInt("PineappleBank");
    }

    // The quit function will only work after the game has been built. Not in preview mode
    public void Quit()
    {
        Application.Quit();
    }
}
