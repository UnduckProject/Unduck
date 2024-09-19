using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GoalManager : MonoBehaviour
{
    public static GoalManager Instance;

    public int totalGoals = 0; 
    public int remainingGoals = 0; 

    public TMP_Text goalCountText; 

    public Canvas victoryCanvas; 
   

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
            ShowVictoryCanvas();
        }
    }

    void UpdateGoalCountText()
    {
        if (goalCountText != null)
        {
            goalCountText.text = $"Goals: {remainingGoals}/{totalGoals}";
        }
    }

    void ShowVictoryCanvas()
    {
        if (victoryCanvas != null)
        {
            
            victoryCanvas.gameObject.SetActive(true);
            DialogueManagerMinigame dialogueManager = FindObjectOfType<DialogueManagerMinigame>();

            if (dialogueManager != null)
            {
                GameManager.Instance.PlusKey();
                dialogueManager.StartDialogue(); 
            }
            else
            {
                Debug.LogError("DialogueManager not found!");
            }
        }
    }
}
