using UnityEngine;

public class FinalHandSwitcher : MonoBehaviour
{
    public GameObject originalModel; 
    public GameObject changeModel;
    public GameObject menu;
    private bool ismenu=false; 

    void Start()
    {
        
        originalModel.SetActive(true);
        changeModel.SetActive(false);
    }

    void Update()
    {
        if(GameData.FirstFinalStage==0){
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

        else if (GameData.FirstFinalStage==1)
        {
            ToggleModel();
            if(OVRInput.GetDown(OVRInput.Button.Start))
            {
                if(!ismenu){
                    changeModel.SetActive(false);
                    menu.SetActive(true);
                    ismenu=true;
                }
                else
                {
                    menu.SetActive(false);
                    changeModel.SetActive(true);
                    ismenu=false;
                }

            }
        }
    }

    void ToggleModel()
    {
        originalModel.SetActive(false);
        changeModel.SetActive(true);
    }
}
