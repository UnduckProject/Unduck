using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Transform target; 
    public float moveSpeed = 1.0f; 

    void Start()
    {
        GameObject cameraRig = GameObject.Find("OVRCameraRig");
        if (cameraRig != null)
        {
            target = cameraRig.transform;
        }
    }
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //정신력 감소
            Destroy(gameObject);
        }

        else if (other.CompareTag("PlayerWeapon"))
        {
            Destroy(gameObject);
        }
    }
}
