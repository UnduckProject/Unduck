using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRButtonInteraction : MonoBehaviour
{
    private Button button;
    private Image buttonImage;

    private void Start()
    {
        button = GetComponent<Button>();
        buttonImage = button.GetComponent<Image>();
        Color color = buttonImage.color;
        color.a = 0f; 
        buttonImage.color = color;
    }

    private void Update()
    {
        // 일시 정지 상태에서도 버튼 클릭을 확인
        if (button.interactable && OVRInput.GetDown(OVRInput.Button.One))
        {
            button.onClick.Invoke(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightController"))
        {
            button.interactable = true;
            Color color = buttonImage.color;
            color.a = 1f; 
            buttonImage.color = color;
            Debug.Log("오른쪽!!!!!!!!!!!!!!!!!!!!!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightController"))
        {
            button.interactable = false;
            Color color = buttonImage.color;
            color.a = 0f; 
            buttonImage.color = color;
            Debug.Log("오른쪽!!!!!!!!!!!!!!!!!!!!아님!!!!!!!!!!!!!");
        }
    }
}
