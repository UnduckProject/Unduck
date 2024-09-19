using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float scaleSpeed = 1f; 
    public Vector3 maxScale; 
    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale; 
    }

    void Update()
    {
        if (transform.localScale.x < maxScale.x && 
            transform.localScale.y < maxScale.y && 
            transform.localScale.z < maxScale.z)
        {
            transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
        }
    }
}
