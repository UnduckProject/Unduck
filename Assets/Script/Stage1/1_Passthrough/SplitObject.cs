using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitObject : MonoBehaviour
{
   // public GameObject[] splitPrefabs;
    //public float splitDistance = 1f;
    public AudioClip[] splitSounds;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            //Vector3 splitDirection = collision.contacts[0].point - transform.position;
            //Split(splitDirection.normalized);
            PlayRandomSplitSound(collision.transform.position);
        }
    }

    private void PlayRandomSplitSound(Vector3 position)
    {
        if (splitSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, splitSounds.Length);
            AudioSource.PlayClipAtPoint(splitSounds[randomIndex], position);
        }
    }

    // private void Split(Vector3 direction)
    // {
        
    //     Vector3 leftDirection = Quaternion.Euler(0, -90, 0) * direction;  
    //     Vector3 rightDirection = Quaternion.Euler(0, 90, 0) * direction; 

    //     Vector3 leftSplitPosition = transform.position + leftDirection * splitDistance;
    //     Vector3 rightSplitPosition = transform.position + rightDirection * splitDistance;

    //     GameObject leftSplitObject = Instantiate(splitPrefabs[0], leftSplitPosition, Quaternion.LookRotation(leftDirection));
    //     GameObject rightSplitObject = Instantiate(splitPrefabs[1], rightSplitPosition, Quaternion.LookRotation(rightDirection));

        
    //     StartCoroutine(DestroyAfterTime(leftSplitObject, 4f));
    //     StartCoroutine(DestroyAfterTime(rightSplitObject, 4f));

    //     Destroy(gameObject);  
    // }

    // private IEnumerator DestroyAfterTime(GameObject obj, float time)
    // {
    //     yield return new WaitForSeconds(time);
    //     Destroy(obj);
    // }
}
