using UnityEngine;
public class FollowWrist : MonoBehaviour
{
    public Transform rightController; 
    public Vector3 offset = new Vector3(0, -0.1f, 0); 

    void Update()
    {
        if (rightController != null)
        {
            transform.position = rightController.position + rightController.rotation * offset;
            transform.rotation = rightController.rotation;
        }
    }
}
