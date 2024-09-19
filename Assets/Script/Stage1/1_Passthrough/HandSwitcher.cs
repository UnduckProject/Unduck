using UnityEngine;

public class HandSwitcher : MonoBehaviour
{
    public GameObject handModel; 
    public GameObject swordModel; 
    private bool isSwordActive = false;

    void Start()
    {
        handModel.SetActive(true);
        swordModel.SetActive(false);
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Button Pressed");
            ToggleModel();
        }
    }

    void ToggleModel()
    {
        isSwordActive = !isSwordActive;
        handModel.SetActive(!isSwordActive);
        swordModel.SetActive(isSwordActive);
    }
}
