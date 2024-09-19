using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMiniGametrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip CoinSound = null;
    private AudioSource mAudioSource = null;
    void Start()
    {
        mAudioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
	void OnTriggerEnter(Collider other) 
    {
		if (other.gameObject.tag.Equals ("Coin")) {
            if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}
			Destroy(other.gameObject);
		}
	}
}