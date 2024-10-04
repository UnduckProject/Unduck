using UnityEngine;
using TMPro;

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

    public void IncreaseScore()
    {
        score++;
        textScore.text = $"Score {score}";
    }

    public void GameOver()
    {
        IsGameOver = true;
        textScore.enabled = false;
        panelResult.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore");

        if (score < highScore)
        {
            textHighScore.text = $"High Score {highScore}";
        }
        else
        {
            PlayerPrefs.SetInt("High Score", score);

            textHighScore.text = $"High Score {score}";
        }

        textResultScore.text = $"Score {score}";
    }
}
