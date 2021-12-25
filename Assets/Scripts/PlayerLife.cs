using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Importing name space for scene management - restart level
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Reference to animator
    private Animator ani;
    // Reference to rigidbody component
    private Rigidbody2D rb;
    // Audio variable
    [SerializeField] private AudioSource deathSound;
    
    private void Start()
    {
        // Instance of Animator
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checking if trap/player collide
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        // Queue audio sound 
        deathSound.Play();
        // Changing body type upon deat - AKA stop allowing movement
        rb.bodyType = RigidbodyType2D.Static;
        ani.SetTrigger("death");

        // Resetting pinapples collected on this level death 
        PlayerPrefs.SetInt("Pineapples", 0);
    }

    private void RestartLevel()
    {
        // reloading the scene, using the active scene which we are in
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
