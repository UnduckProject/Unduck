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
            Transform trackingSpace = cameraRig.transform.Find("TrackingSpace");
            if (trackingSpace != null)
            {
                target = trackingSpace.Find("CenterEyeAnchor");
            }
        }


        if (target == null)
        {
            Debug.LogWarning("CenterEyeAnchor를 찾을 수 없습니다. 타겟이 null입니다.");
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

        if (other.CompareTag("PlayerWeapon"))
        {
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
