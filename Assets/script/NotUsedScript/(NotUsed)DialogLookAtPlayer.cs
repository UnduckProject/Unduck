using UnityEngine;

public class FollowCameraCenter : MonoBehaviour
{
    public Camera mainCamera; // 메인 카메라

    private RectTransform rectTransform; // 자막의 RectTransform

    void Start()
    {
        // 자막의 RectTransform 컴포넌트를 가져옵니다.
        rectTransform = GetComponent<RectTransform>();

        // 메인 카메라가 설정되지 않은 경우, 자동으로 카메라를 할당합니다.
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // 초기 위치를 화면 중앙으로 설정
        rectTransform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    void Update()
    {
        // 자막을 화면 중앙에 고정
        rectTransform.position = new Vector2(Screen.width / 2, Screen.height / 2);
    }
}
