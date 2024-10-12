using UnityEngine;
using System.Collections;
public class SpawnDanseo : MonoBehaviour
{
    private GameObject objectToActivate;

    void Start()
    {
        objectToActivate = GameObject.Find("[BuildingBlock] Find Spawn Positions");
        
        if (objectToActivate != null)
        {
            StartCoroutine(ActivateObjectAfterDelay(4f));
        }
        else
        {
            Debug.LogError("오브젝트를 찾을 수 없습니다.");
        }
    }

    IEnumerator ActivateObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToActivate.SetActive(true);
    }
}
