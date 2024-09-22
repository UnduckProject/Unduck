using UnityEngine;

public class MenuFollow : MonoBehaviour
{
    public Transform controller; 

    void Update()
    {
        if (controller != null)
        {
            Vector3 newPosition = controller.position;
            newPosition.y += 0.1f;
            transform.position = newPosition;
            transform.rotation = controller.rotation * Quaternion.Euler(0, 180, 0);
        }
    }
}
