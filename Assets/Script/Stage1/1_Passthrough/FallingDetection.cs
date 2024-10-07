using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingDetection : MonoBehaviour
{
    public Transform centerEye;
    public float checkDistance = 2f;
    private float delay = 2f; 
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer < delay) return; 

        RaycastHit hit;

    
        if (!Physics.Raycast(centerEye.position, Vector3.down, out hit, checkDistance))
        {
            GameData.duckwan=false;
            SceneManager.LoadScene("GameOver");
        }
    }
}
