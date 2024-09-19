using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("PlayCoinSound", 0f, 5f); // 코인 존재 시 사운드 재생
    }

    void PlayCoinSound()
    {
        audioSource.Play(); // 사운드 재생
    }
}