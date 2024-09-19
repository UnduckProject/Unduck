using UnityEngine;

public class FallingDetection : MonoBehaviour
{
    public Transform centerEye; 
    public float checkDistance = 2f; 

    void Update()
    {
        
        RaycastHit hit;
        if (!Physics.Raycast(centerEye.position, Vector3.down, out hit, checkDistance))
        {
            
            GetComponent<Rigidbody>().isKinematic = false; 
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
