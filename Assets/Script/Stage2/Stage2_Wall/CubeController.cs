using UnityEngine;

public class CubeController : MonoBehaviour
{
    private CubeSpawner cubeSpawner;
    private CubeChecker cubeChecker;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource; // AudioSource 추가
    private int colorIndex;

    public void Setup(CubeSpawner cubeSpawner, CubeChecker cubeChecker)
    {
        this.cubeSpawner = cubeSpawner;
        this.cubeChecker = cubeChecker;

        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트 가져오기
        meshRenderer.material.color = this.cubeSpawner.CubeColors[0];
        colorIndex = 0;
    }

    public void ChangeColor()
    {
        if (colorIndex < cubeSpawner.CubeColors.Length - 1)
        {
            colorIndex++;
        }
        else
        {
            colorIndex = 0;
        }

        meshRenderer.material.color = cubeSpawner.CubeColors[colorIndex];

        // 색상 변경 시 오디오 재생
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer renderer = other.GetComponent<MeshRenderer>();

        if (meshRenderer.material.color == renderer.material.color)
        {
            cubeChecker.CorrectCount++;
        }
        else
        {
            cubeChecker.IncorrectCount++;
        }
    }
}
