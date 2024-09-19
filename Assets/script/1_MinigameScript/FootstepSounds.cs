using UnityEngine;
using System.Collections;
public class FootstepSounds : MonoBehaviour {

    public OVRPlayerController playerController; 
    public AudioClip footstepSound; 
    public float footstepVolume = 1f;
    private AudioSource audioSource;
    private bool isMoving;
    private bool isPlayingSound;

    private void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = footstepSound;
        audioSource.loop = false; 
    }

    private void Update() {
        MoveCheck();
    }

    private void MoveCheck() {
        
        Vector3 velocity = playerController.GetComponent<CharacterController>().velocity;

        if (velocity.magnitude > 0.1f) {
            if (!isMoving) {
                isMoving = true;
                StartCoroutine(PlayFootstepSound()); 
            }
        } else {
            isMoving = false;
            isPlayingSound = false; 
        }
    }

    private IEnumerator PlayFootstepSound() {
        while (isMoving) {
            if (!isPlayingSound) {
                isPlayingSound = true; 
                audioSource.volume = footstepVolume;
                audioSource.PlayOneShot(footstepSound); 
                yield return new WaitForSeconds(0.5f); 
                isPlayingSound = false; 
            }
            yield return null; 
        }
    }
}
