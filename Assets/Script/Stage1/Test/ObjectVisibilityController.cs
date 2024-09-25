using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    public GameObject danseo;
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 directionToObject = (danseo.transform.position - cameraTransform.position).normalized;

        if (Physics.Raycast(cameraTransform.position, directionToObject, out hit))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                MeshRenderer renderer = danseo.GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.enabled = false;
                }
            }
            else
            {
                MeshRenderer renderer = danseo.GetComponentInChildren<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.enabled = true;
                }
            }
        }
    }
}
