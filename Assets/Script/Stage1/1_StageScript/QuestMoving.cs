using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMoving : MonoBehaviour
{
    public float amplitude = 0.5f; 
    public float frequency = 1.0f; 

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
