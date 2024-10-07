using UnityEngine;

public class CubeController : MonoBehaviour
{
    private CubeSpawner cubeSpawner;
    private CubeChecker cubeChecker;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource; // AudioSource �߰�
    private int colorIndex;

    public void Setup(CubeSpawner cubeSpawner, CubeChecker cubeChecker)
    {
        this.cubeSpawner = cubeSpawner;
        this.cubeChecker = cubeChecker;

        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>(); // AudioSource ������Ʈ ��������
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

        // ���� ���� �� ����� ���
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
