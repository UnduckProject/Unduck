using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{
    public GameManager1 manager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            manager.StageStart();
    }
}
