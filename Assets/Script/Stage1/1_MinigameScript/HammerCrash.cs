using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCrash : MonoBehaviour
{
    public GameObject hammer;
    private int naegudo=6;
    private AudioSource audioSource;

    void Start()
    {
        naegudo=6;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(naegudo == 0)
        {
            Destroy(hammer);
        }
    }
    // Start is called before the first frame update
     private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag == "MazeWall")
         {
            naegudo--;
            audioSource.Play();
            Destroy(other.gameObject);
         }
     }

}
