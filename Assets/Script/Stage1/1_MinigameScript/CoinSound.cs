using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayCoinSound", 0f, 5f); 
    }

    void PlayCoinSound()
    {
        audioSource.Play(); 
    }
}