using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // If this platform, collides with an object called Player - collision ENTER
        if(collision.gameObject.name == "Player")
        {
            // making the player a child of the moving platform 
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If the player leaves the platform - collision EXIT 
        if(collision.gameObject.name == "Player")
        {
            // Releasing the player object and setting the parent to null
            collision.gameObject.transform.SetParent(null);
        }
    }
}