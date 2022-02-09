using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AudioClip bellSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
        
        if (collision.collider.CompareTag("Obstacle"))
            audioSource.PlayOneShot(bellSound, 0.5f);
            
    }
}
