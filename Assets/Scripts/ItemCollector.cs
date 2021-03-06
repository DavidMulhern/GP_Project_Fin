using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// importing text name space
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Counter
    private int pineappleCount; // HERE WAS = 0;

    // Text on screen showing collection tally
    [SerializeField] private Text pineappleText;
    // Audio variable 
    [SerializeField] private AudioSource collectionSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pineapple"))
        {
            // Remove object after collection and add to counter used for on screen display
            Destroy(collision.gameObject);
            pineappleCount++;

            // Storing pineapple values in PlayerPrefs
            PlayerPrefs.SetInt("Pineapples", pineappleCount); 
            // Current pineapple display
            pineappleText.text = "Pineapples in bag: " + pineappleCount; 
            // Queue audio sound 
            collectionSound.Play();

            Debug.Log(PlayerPrefs.GetInt("Pineapples"));
            Debug.Log(PlayerPrefs.GetInt("PineappleBank"));
        }
    }
}
