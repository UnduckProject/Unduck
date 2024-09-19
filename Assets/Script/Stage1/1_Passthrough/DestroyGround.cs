using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGround : MonoBehaviour
{
    public AudioClip breakSound;
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("brokenGround"))
        {
            AudioSource.PlayClipAtPoint(breakSound, collision.transform.position);
            Destroy(collision.gameObject);
        }
    }

}
