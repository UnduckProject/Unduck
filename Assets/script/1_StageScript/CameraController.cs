using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public BoxCollider movementBounds; 

    private Vector3 moveDirection;

    void Update()
    {
        
        Vector2 joystickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        
        moveDirection = new Vector3(joystickInput.x, 0, joystickInput.y);
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        
        newPosition = KeepWithinBounds(newPosition);

        
        transform.position = newPosition;
    }

    
    Vector3 KeepWithinBounds(Vector3 position)
    {
        Vector3 minBounds = movementBounds.bounds.min;
        Vector3 maxBounds = movementBounds.bounds.max;

        position.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        position.y = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);
        position.z = Mathf.Clamp(position.z, minBounds.z, maxBounds.z);

        return position;
    }
}
