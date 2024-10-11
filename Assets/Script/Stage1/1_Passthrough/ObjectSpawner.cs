using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour {

    public GameObject[] objectPrefabs; 
    public GameObject monsterPrefab; 
    public AudioClip monsterSound;
    public AudioClip rockSound; 
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
                GameData.duckwan=false;
                GameData.Win=true;
                GameData.GameProgress=2;
                if(GameData.Demo)
                {
                    SceneManager.LoadScene("NewMenu");
                }
                else{
                    SceneManager.LoadScene("Stage1");
                }
 
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
                Random.Range(-15, spawnArea.x),
                Random.Range(10, spawnArea.y), 
                Random.Range(-15, spawnArea.z)
            );
    } while (spawnPosition.x > -10 && spawnPosition.x < 10 && spawnPosition.z > -10 && spawnPosition.z < 10);

        Vector3 monsterSpawnPosition = new Vector3(spawnPosition.x , spawnPosition.y - 2f, spawnPosition.z);
     

        GameObject monster = Instantiate(monsterPrefab, monsterSpawnPosition, Quaternion.identity);
        AudioSource.PlayClipAtPoint(monsterSound, monsterSpawnPosition,3f);

        Vector3 directionToPlayer = (player.position - monsterSpawnPosition).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        monster.transform.rotation = lookRotation;

        yield return new WaitForSeconds(1.5f);


        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject selectedPrefab = objectPrefabs[randomIndex];

        GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        
        Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();
        Vector3 direction = (player.position - spawnPosition).normalized;
        AudioSource.PlayClipAtPoint(rockSound, monsterSpawnPosition);
        rb.AddForce(direction * 25f, ForceMode.Impulse);

        Destroy(monster, 1f);
    }
}
