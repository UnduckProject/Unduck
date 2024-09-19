using UnityEngine;
using UnityEngine.UI;

public class VRUIController : MonoBehaviour
{
    public Button[] buttons;
    public Canvas uiCanvas; // UI Canvas 또는 패널을 참조할 변수
    private int currentIndex = 0;

    void Update()
    {
        // OVRInput 클래스를 직접 참조하여 조이스틱 입력 처리
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickUp))
        {
            currentIndex = (currentIndex > 0) ? currentIndex - 1 : buttons.Length - 1;
            UpdateButtonSelection();
        }
        else if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickDown))
        {
            currentIndex = (currentIndex < buttons.Length - 1) ? currentIndex + 1 : 0;
            UpdateButtonSelection();
        }

        // 선택된 버튼 클릭 처리
        if (OVRInput.GetDown(OVRInput.Button.One)) // A버튼
        {
            buttons[currentIndex].onClick.Invoke();
        }
    }

    void UpdateButtonSelection()
    {
        // 모든 버튼의 상태를 초기화
        foreach (var button in buttons)
        {
            button.GetComponent<Image>().color = Color.white; // 기본 색상
        }


    }

    // 캔버스 또는 패널을 닫는 메서드
    public void CloseCanvas()
    {
        if (uiCanvas != null)
        {
            uiCanvas.gameObject.SetActive(false);
        }
    }
}
