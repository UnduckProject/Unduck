using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraMover : MonoBehaviour
{
    public Transform target; 
    public float speed = 1.0f; 

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                isMoving = false; 
                transform.position = target.position; 
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }
}
