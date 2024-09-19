using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class realFinalObjectSpawner : MonoBehaviour {

    public GameObject[] objectPrefabs; 
    public GameObject monsterPrefab; 
    public AudioClip monsterSound; 
    public float spawnInterval = 1f; 
    public Vector3 spawnArea; 
    public Transform player; 
    public Slider PlayerHp;
    public Slider BossHp;

    private bool isSpawning = true;

    private void Start() {
        InvokeRepeating("SpawnObject", 0, spawnInterval);
        PlayerHp.gameObject.SetActive(true);
        BossHp.gameObject.SetActive(true);
    }

    private void Update() { 
        if (BossHp.value <= 0) {
            isSpawning = false;
            CancelInvoke("SpawnObject"); 
            SceneManager.LoadScene("Stage1");
        }

        if (PlayerHp.value <= 0) {
            isSpawning = false;
            CancelInvoke("SpawnObject");
            GameData.FirstBossHP=100;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void SpawnObject() {
        if (!isSpawning) return; 

        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay() {
        Vector3 spawnPosition;
        Vector3 monsterSpawnPosition;

        do {
            spawnPosition = new Vector3(
                Random.Range(-20, spawnArea.x),
                Random.Range(20, spawnArea.y), 
                Random.Range(-20, spawnArea.z)
            );
        } while (spawnPosition.x > -15 && spawnPosition.x < 15 && spawnPosition.z > -15 && spawnPosition.z < 15);

        if (spawnPosition.z > 0) {
            monsterSpawnPosition = new Vector3(spawnPosition.x - 1.5f, spawnPosition.y - 2.5f, spawnPosition.z + 5f);
        } else {
            monsterSpawnPosition = new Vector3(spawnPosition.x - 1.5f, spawnPosition.y - 2.5f, spawnPosition.z - 5f);
        }
        GameData.FirstBossTransform=monsterSpawnPosition;

        GameObject monster = Instantiate(monsterPrefab, monsterSpawnPosition, Quaternion.identity);
        AudioSource.PlayClipAtPoint(monsterSound, monsterSpawnPosition);

        Vector3 directionToPlayer = (player.position - monsterSpawnPosition).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        monster.transform.rotation = lookRotation;

        yield return new WaitForSeconds(3f);

        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        
        Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();
        Vector3 direction = (player.position - spawnPosition).normalized;
        rb.AddForce(direction * 55f, ForceMode.Impulse);

        Destroy(monster, 3f);
    }
}
