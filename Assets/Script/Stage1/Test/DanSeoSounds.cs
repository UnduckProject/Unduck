using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanSeoSounds : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="item")
            audioSource.Play();
    }
}
