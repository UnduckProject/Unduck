using UnityEngine;

public class FinalHandSwitcherRight : MonoBehaviour
{
    public GameObject originalModel; 
    public GameObject changeModel;

    void Start()
    {
        
        originalModel.SetActive(true);
        changeModel.SetActive(false);
    }

    void Update()
    {

        if (GameData.FirstFinalStage==1)
        {
            ToggleModel();
        }
    }

    void ToggleModel()
    {
        originalModel.SetActive(false);
        changeModel.SetActive(true);
    }
}
