using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseoIn : MonoBehaviour
{
    private MRStageManager mrManager;
    private AudioSource audioSource;

    void Start()
    {
        mrManager = FindObjectOfType<MRStageManager>();
        audioSource = GetComponent<AudioSource>();
    }
      private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Danseo")
        {
            mrManager.addPoint();
            audioSource.Play();
            ParticleSystem particleSystem = other.gameObject.GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
            Destroy(gameObject);
        }
    }

}
