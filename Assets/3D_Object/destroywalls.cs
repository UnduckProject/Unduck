using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroywalls : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "wall")
        {
            
            Destroy(other.gameObject);
        }
    }

}
