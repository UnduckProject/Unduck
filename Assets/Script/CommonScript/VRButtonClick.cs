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
