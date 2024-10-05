using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerWall : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textScore;
    private int score = 0;

    [SerializeField]
    private GameObject panelResult;
    [SerializeField]
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private TextMeshProUGUI textHighScore;

    public bool IsGameOver { private set; get; }

    private void Awake()
    {
        IsGameOver = false;
    }

    void Update()
    {
        if(score == 1)
        {
            GameData.Win=true;
            GameData.GameProgress=7;
            GameData.Winprogress = 4;
            SceneManager.LoadScene("Stage2");
        }
    }

    public void IncreaseScore()
    {
        score++;
        textScore.text = $"Score {score}";
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
