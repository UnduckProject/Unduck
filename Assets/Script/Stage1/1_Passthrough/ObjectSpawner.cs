using UnityEngine;
using UnityEngine.UI; // UI 사용을 위해 추가
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour {

    public GameObject[] objectPrefabs; 
    public GameObject monsterPrefab; 
    public AudioClip monsterSound; 
    public float spawnInterval = 1f; 
    public Vector3 spawnArea; 
    public Transform player; 
    public TMP_Text timerText; 

    public float timer = 1f; 
    private bool isSpawning = true;

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
                GameManager.Instance.PlusKey();
                GameData.LoadSceneName="Stage1";
                SceneManager.LoadScene("Loading");
 
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
                Random.Range(-8, spawnArea.x),
                Random.Range(2, spawnArea.y), 
                Random.Range(-8, spawnArea.z)
            );
    } while (spawnPosition.x > -5 && spawnPosition.x < 5 && spawnPosition.z > -5 && spawnPosition.z < 5);

        Vector3 monsterSpawnPosition = new Vector3(spawnPosition.x - 1.5f, spawnPosition.y - 2.5f, spawnPosition.z);

        GameObject monster = Instantiate(monsterPrefab, monsterSpawnPosition, Quaternion.identity);
        AudioSource.PlayClipAtPoint(monsterSound, monsterSpawnPosition);

        Vector3 directionToPlayer = (player.position - monsterSpawnPosition).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        monster.transform.rotation = lookRotation;

        yield return new WaitForSeconds(2f);

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        
        Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();
        Vector3 direction = (player.position - spawnPosition).normalized;
        rb.AddForce(direction * 17f, ForceMode.Impulse);

        Destroy(monster, 1f);
    }
}
