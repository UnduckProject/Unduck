using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ZombieAttack : MonoBehaviour
{
    private bool isTriggered = false;
    private int playerChance;
    public TMP_Text chanceCountText;
    public Transform spawnPosition;

    void Start()
    {
        playerChance = 3;
        UpdateChanceCountText();
    }

    void Update()
    {
        if (playerChance <= 0)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("attack") && !isTriggered)
        {
            isTriggered = true;
            StartCoroutine(DamagePlayer(1f));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("attack"))
        {
            isTriggered = false;
        }
    }

    private IEnumerator DamagePlayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (isTriggered)
        {
            playerChance--;
            transform.position = spawnPosition.position; 
            Debug.Log("New Position: " + transform.position);
            UpdateChanceCountText();
        }
    }

    void UpdateChanceCountText()
    {
        if (chanceCountText != null)
        {
            chanceCountText.text = $"Chance: {playerChance}/3";
        }
    }
}