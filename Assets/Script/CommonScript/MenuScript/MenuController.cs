using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public EventSystem eventSystem;
    public Button[] menuButtons; // Continue, NewGame, Settings, Quit
    private int currentIndex = 0;

    void Start()
    {
        Debug.Log("Menu Buttons Count: " + menuButtons.Length);
        UpdateMenuSelection();
    }


    void Update()
    {
        // 조이스틱 입력 체크
        float verticalInput = Input.GetAxis("Vertical"); // 조이스틱 수직 입력

        if (verticalInput > 0)
        {
            currentIndex = (currentIndex - 1 + menuButtons.Length) % menuButtons.Length;
            UpdateMenuSelection();
        }
        else if (verticalInput < 0)
        {
            currentIndex = (currentIndex + 1) % menuButtons.Length;
            UpdateMenuSelection();
        }

        // B 버튼 입력 체크
        if (OVRInput.GetDown(OVRInput.Button.Two)) // B 버튼에 해당
        {
            menuButtons[currentIndex].onClick.Invoke(); // 현재 선택된 버튼 클릭
        }
    }

void UpdateMenuSelection()
{
    if (currentIndex < 0 || currentIndex >= menuButtons.Length)
    {
        return; // 인덱스가 유효하지 않으면 메서드 종료
    }

    for (int i = 0; i < menuButtons.Length; i++)
    {
        if (menuButtons[i] != null) // null 체크 추가
        {
            Color color = (i == currentIndex) ? Color.white : new Color(1, 1, 1, 0.5f);
            menuButtons[i].GetComponent<Image>().color = color; // 선택된 버튼 색상 변경
        }
    }
    
    if (menuButtons[currentIndex] != null) // null 체크 추가
    {
        eventSystem.SetSelectedGameObject(menuButtons[currentIndex].gameObject);
    }
}


}
