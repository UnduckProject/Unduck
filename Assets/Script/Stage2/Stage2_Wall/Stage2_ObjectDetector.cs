using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RaycastEvent : UnityEvent<Transform> { }

public class Stage2_ObjectDetector : MonoBehaviour
{
    [HideInInspector]
    public RaycastEvent raycastEvent = new RaycastEvent();

    [SerializeField]
    private LayerMask layerMask;
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}


