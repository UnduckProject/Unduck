using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; 
    public float followSpeed = 5f; 
    public Vector3 offset; 

    void Update()
    {
        if (target != null)
        {
            
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
