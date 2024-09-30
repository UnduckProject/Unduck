using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigamesystem : MonoBehaviour
{
    public GameObject Ghost;
    public GameObject Portal;
    // Start is called before the first frame update
    void Update()
    {
        if(GameData.GameProgress==3){
            Ghost.SetActive(true);
        }
        else if(GameData.GameProgress==2)
        {
            Portal.SetActive(true);
        }

        if (GoalManager.Instance != null)
        {
            GoalManager.Instance.Initialize();
            GameData.minigameOn=false; 
        }
        else
        {
            Debug.LogWarning("GoalManager 인스턴스가 존재하지 않습니다.");
        }

         if (FinalGoalManager.Instance != null)
        {
            FinalGoalManager.Instance.Initialize();
        }
        else
        {
            Debug.LogWarning("FinalGoalManager instance is not available.");
        }
    }

}
