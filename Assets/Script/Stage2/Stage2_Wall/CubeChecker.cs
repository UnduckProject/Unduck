using UnityEngine;

public class CubeChecker : MonoBehaviour
{
    [SerializeField]
    private CubeSpawner cubeSpawner;
    [SerializeField]
    private GameControllerWall gameControllerWall;

    private CubeController[] touchCubes;

    private int correctCount = 0;
    private int incorrectCount = 0;

    public int CorrectCount
    {
        set => correctCount = Mathf.Max(0, value);
        get => correctCount;
    }

    public int IncorrectCount
    {
        set => incorrectCount = Mathf.Max(0, value);
        get => incorrectCount;
    }

    private void Awake()
    {
        touchCubes = GetComponentsInChildren<CubeController>();

        for (int i =0; i< touchCubes.Length; ++i)
        {
            touchCubes[i].Setup(cubeSpawner, this);
        }
    }

    private void Update()
    {
        if (gameControllerWall.IsGameOver == true) return;

        if(CorrectCount + IncorrectCount == touchCubes.Length)
        {
            if (IncorrectCount == 0)
            {
                // Debug.Log("Success");
                gameControllerWall.IncreaseScore();
            }
            else
            {
                // Debug.Log("Falied");
                gameControllerWall.GameOver();
            }

            CorrectCount = 0;
            IncorrectCount = 0;
        }
    }
}
