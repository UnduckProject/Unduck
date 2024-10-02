using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMiniGameHammer : MonoBehaviour
{
    [SerializeField]
    private GameObject moleHitEffectPrefab;
    [SerializeField]
    private AudioClip[] audioClips;
    [SerializeField]
    private MoleHitTextViewer[] moleHitTextViewer; 
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private ObjectDetector objectDetector;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FindMoleHitTextViewersCoroutine()); 
    }

    private IEnumerator FindMoleHitTextViewersCoroutine()
    {
        while (true)
        {
            GameObject spawnGameObject = GameObject.Find("SpawnGame");
            if (spawnGameObject != null)
            {
                Transform gameTransform = spawnGameObject.transform.Find("Game(Clone)");
                if (gameTransform != null)
                {
                    Transform canvas = gameTransform.Find("Canvas");
                    if (canvas != null)
                    {
                        
                        moleHitTextViewer = canvas.GetComponentsInChildren<MoleHitTextViewer>(true);
                        break; 
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mole"))
        {
            Debug.Log("충돌충돌충돌충돌충돌충돌충돌충돌충돌충돌충돌");
            MoleFSM mole = other.GetComponent<MoleFSM>();
            if (mole.MoleState == MoleState.UnderGround) return;
            mole.ChangeState(MoleState.UnderGround);

            GameObject clone = Instantiate(moleHitEffectPrefab, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = clone.GetComponent<ParticleSystem>().main;
            main.startColor = mole.GetComponent<MeshRenderer>().material.color;

            MoleHitProcess(mole);
        }
    }

    private void MoleHitProcess(MoleFSM mole)
    {
        if (mole.MoleType == MoleType.Normal)
        {
            gameController.NormalMoleHitCount++;
            gameController.Combo++;
            float scoreMultiple = 1 + gameController.Combo / 10 * 0.5f;
            int getScore = (int)(scoreMultiple * 50);

            gameController.Score += getScore;

            moleHitTextViewer[mole.MoleIndex].OnHit("Score +" + getScore, Color.white);
        }
        else if (mole.MoleType == MoleType.Red)
        {
            gameController.RedMoleHitCount++;
            gameController.Combo = 0;
            gameController.Score -= 300;
            moleHitTextViewer[mole.MoleIndex].OnHit("Score -300", Color.red);
        }
        else if (mole.MoleType == MoleType.Blue)
        {
            gameController.BlueMoleHitCount++;
            gameController.Combo++;
            gameController.CurrentTime += 3;
            moleHitTextViewer[mole.MoleIndex].OnHit("Time +3", Color.blue);
        }

        PlaySound((int)mole.MoleType);
    }

    private void PlaySound(int index)
    {
        audioSource.Stop();
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
