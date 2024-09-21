using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    public Transform floor;
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(floor.position.x, floor.position.y + 2, floor.position.z);
        }
    }
}
