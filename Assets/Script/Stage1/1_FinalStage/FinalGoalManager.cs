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
    public GameObject objSpawn;
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
    public void Initialize()
    {
        totalGoals = 0;
        GameData.isBoss = false; 
        GameData.FirstFinalStage = 0;
        GameData.FirstBossHP=100;
    }
    void Update()
    {
        Transform parentTransform = GameObject.Find("ParentGameObject")?.transform;
        if (parentTransform != null)
        {
            RealFinalStage = parentTransform.Find("realFinalStage")?.gameObject;
        }

        if(WTimer == null)
        {
            WTimer = GameObject.Find("WristTimer");
        }
        if(objSpawn == null)
        {
            objSpawn = GameObject.Find("ObjectSpawn");
        }
        if (goalCountText == null)
        {
            goalCountText = GameObject.Find("WristText")?.GetComponent<TMP_Text>();
            MazeMap = GameObject.Find("MazeSpawn (1)");
            if (goalCountText != null)
            {
                UpdateGoalCountText();
                Debug.Log("WristText found and updated.");
            }
            else
            {
                Debug.LogWarning("WristText not found!");
            }
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
            objSpawn.gameObject.SetActive(false);
            GameData.isBoss=false;
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
