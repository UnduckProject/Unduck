using UnityEngine;

public class GoalScript : MonoBehaviour
{
    private bool isRegistered = false; 

    void Start()
    {
        if (!isRegistered && GameData.GameProgress == 1) 
        {
            GoalManager.Instance.RegisterGoal();
            isRegistered = true; 
        }

        else if(!isRegistered && GameData.GameProgress == 3)
        {
            FinalGoalManager.Instance.RegisterGoal();
            isRegistered = true; 
        }
    }

    void OnDestroy()
    {
        if (isRegistered && GameData.GameProgress==1) 
        {
            GoalManager.Instance.GoalDestroyed();
            isRegistered = false;
        }
        else if(isRegistered && GameData.GameProgress == 3)
        {
            FinalGoalManager.Instance.GoalDestroyed();
            isRegistered = false;
        }
    }
}
