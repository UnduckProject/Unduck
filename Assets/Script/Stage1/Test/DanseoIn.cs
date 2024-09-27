using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanseoIn : MonoBehaviour
{
    private MRStageManager mrManager;

    void Start()
    {
        mrManager = FindObjectOfType<MRStageManager>();
    }
      private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Danseo")
        {
            mrManager.addPoint();
            ParticleSystem particleSystem = other.gameObject.GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
            Destroy(gameObject);
        }
    }

}
