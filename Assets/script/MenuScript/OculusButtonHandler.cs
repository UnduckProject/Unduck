using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OculusButtonHandler : MonoBehaviour
{
    public Button Newgame; // Newgame 버튼에 대한 참조

    void Update()
    {
        HandleOVRInput();
    }

    private void HandleOVRInput()
    {
        // B 버튼을 눌렀을 때 Newgame 버튼의 onClick 이벤트를 호출합니다.
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            Debug.Log("B Button Pressed");

            if (Newgame != null)
            {
                // Newgame 버튼의 onClick 이벤트를 호출
                Newgame.onClick.Invoke();
                Debug.Log("Newgame Button Clicked");
            }
            else
            {
                Debug.LogWarning("Newgame Button reference is not set.");
            }
        }
    }
}
