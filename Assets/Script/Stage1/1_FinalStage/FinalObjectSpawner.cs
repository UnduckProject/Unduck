using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalObjectSpawner : MonoBehaviour {

    public GameObject[] objectPrefabs; 
    public GameObject monsterPrefab; 
    public AudioClip monsterSound; 
    public float spawnInterval = 1f; 
    public Vector3 spawnArea; 
    public Transform player; 
    public TMP_Text timerText; 

    public float timer = 1f; 
    private bool isSpawning = true;

    private GameObject currentMonster; 

    private void Start() {
        InvokeRepeating("SpawnObject", 0, spawnInterval);
        timerText.gameObject.SetActive(true);
    }

    private void Update() {
        if (isSpawning) {
            timer -= Time.deltaTime; 
            timerText.text = "남은 시간: " + Mathf.Max(0, Mathf.Ceil(timer)).ToString(); 

            if (timer <= 0) {
                isSpawning = false;
                CancelInvoke("SpawnObject"); 
                timerText.text = "시간 종료!";
                
                
                if (currentMonster != null) {
                    Destroy(currentMonster);
                }

                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private void SpawnObject() {
        if (!isSpawning) return; 

        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay() {
        Vector3 spawnPosition;
        do {
            spawnPosition = new Vector3(
                Random.Range(-3, spawnArea.x),
                Random.Range(18, spawnArea.y), 
                Random.Range(-3, spawnArea.z)
            );
        } while (spawnPosition.x > 0 && spawnPosition.x < 10 && spawnPosition.z > 0 && spawnPosition.z < 10);

        Vector3 monsterSpawnPosition = new Vector3(spawnPosition.x - 1.5f, spawnPosition.y - 2.5f, spawnPosition.z);

        currentMonster = Instantiate(monsterPrefab, monsterSpawnPosition, Quaternion.identity); 
        AudioSource.PlayClipAtPoint(monsterSound, monsterSpawnPosition);

        Vector3 directionToPlayer = (player.position - monsterSpawnPosition).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        currentMonster.transform.rotation = lookRotation;

        yield return new WaitForSeconds(2f);

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        
        Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();
        Vector3 direction = (player.position - spawnPosition).normalized;
        rb.AddForce(direction * 25f, ForceMode.Impulse);

        Destroy(currentMonster, 1f); 
    }

    public void SubtractTime(float amount) {
        timer -= amount;
        if (timer < 0) {
            timer = 0; 
        }
    }
}
