using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    private FinalObjectSpawner finalobjectspawner;

    private void Start()
    {
        finalobjectspawner = FindObjectOfType<FinalObjectSpawner>();
    }
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finalobjectspawner.SubtractTime(10f);
        }
    }

}
