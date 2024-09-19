using UnityEngine;

public class HandSwitcher : MonoBehaviour
{
    public GameObject handModel; // 손 모델
    public GameObject swordModel; // 칼 모델
    private bool isSwordActive = false;

    void Start()
    {
        // 초기에는 손 모델만 활성화
        handModel.SetActive(true);
        swordModel.SetActive(false);
    }

    void Update()
    {
        // 버튼 입력 체크 (여기서는 A 버튼을 사용)
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
