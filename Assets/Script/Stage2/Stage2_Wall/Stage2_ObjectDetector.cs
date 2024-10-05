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
        // "MainCamera" 태그를 가지고 있는 오브젝트 탐색 후 Camera 컴포넌트 정보 전달
        // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 와 동일
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 카메라 위치에서 화면의 마우스 위치를 관통하는 광선 생성
            // ray.origin : 광선의 시작위치(=카메라 위치)
            // ray.direction : 광선의 진행방향
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // 2D 모니터를 통해 3D 월드의 오브젝트를 마우스로 선택하는 방법
            // 광선에 부딪히는 오브젝트를 검출해서 hit에 저장
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                // 부딪힌 오브젝트의 Transform 정보를 매개변수로 이벤트 호출
                raycastEvent.Invoke(hit.transform);
            }
        }
    }
}
