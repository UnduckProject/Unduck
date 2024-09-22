using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class FinalGoalManager : MonoBehaviour
{
    
    public static FinalGoalManager Instance;
    
    public int totalGoals = 0; 
    public int remainingGoals = 0; 

    public TMP_Text goalCountText;

    public GameObject WTimer;
    public GameObject MazeMap; 
    public GameObject ObjectSpawn;
    public GameObject RealFinalStage;
   

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterGoal()
    {
        totalGoals++;
        remainingGoals++;
        UpdateGoalCountText();
    }

    public void GoalDestroyed()
    {
        remainingGoals--;
        UpdateGoalCountText();

        if (remainingGoals <= 0)
        {
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
            foreach (GameObject monster in monsters)
            {
                Destroy(monster);
            }

            WTimer.gameObject.SetActive(false);
            goalCountText.gameObject.SetActive(false);
            MazeMap.gameObject.SetActive(false);
            ObjectSpawn.gameObject.SetActive(false);

            RealFinalStage.gameObject.SetActive(true);
        }
    }

    void UpdateGoalCountText()
    {
        if (goalCountText != null)
        {
            goalCountText.text = $"Goals: {remainingGoals}/{totalGoals}";
        }
    }
}
