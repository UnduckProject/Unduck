using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGhost : MonoBehaviour
{
    public AudioClip attackSounds;

    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "attack")
            {
                ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
                AudioSource.PlayClipAtPoint(attackSounds,other.transform.position);
                if (particleSystem != null)
                {
                    particleSystem.Play();
                }
                Destroy(other.gameObject);
            }
        }

}
