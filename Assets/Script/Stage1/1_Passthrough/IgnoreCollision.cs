using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    
    public string ignoreTag = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ignoreTag))
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), other);
        }
    }
}
