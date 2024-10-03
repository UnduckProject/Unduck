using UnityEngine;

public class CubeSelector : MonoBehaviour
{
    private Stage2_ObjectDetector objectDetector;
    
    private void Awake()
    {
        objectDetector = GetComponent<Stage2_ObjectDetector>();

        objectDetector.raycastEvent.AddListener(SelectCube);
    }

    public void SelectCube(Transform hit)
    {
        hit.GetComponent<CubeController>().ChangeColor();
    }
}
