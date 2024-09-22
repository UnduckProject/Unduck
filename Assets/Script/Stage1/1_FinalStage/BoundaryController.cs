using UnityEngine;

public class BoudaryController : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the boundary!");

            CharacterController characterController = other.GetComponent<CharacterController>();
            if (characterController != null)
            {
                Vector3 spawnPosition = spawnPoint.position;
                characterController.enabled = false; 
                other.transform.position = spawnPosition;
                characterController.enabled = true;
            }
        }
    }
}