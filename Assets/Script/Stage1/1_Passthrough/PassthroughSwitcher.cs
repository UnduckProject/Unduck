using UnityEngine;

public class PassthroughSwitcher : MonoBehaviour
{
    public GameObject originalModel; 
    public GameObject menu;
    private bool ismenu=false; 

    void Start()
    { 
        originalModel.SetActive(true);
    }

    void Update()
    {
            if(OVRInput.GetDown(OVRInput.Button.Start))
            {
                if(!ismenu){
                    originalModel.SetActive(false);
                    menu.SetActive(true);
                    ismenu=true;
                }
                else
                {
                    menu.SetActive(false);
                    originalModel.SetActive(true);
                    ismenu=false;
                }
            }
    }

}
