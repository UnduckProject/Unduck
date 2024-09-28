using System.Collections;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private MoleFSM[] moles;
    [SerializeField]
    private float spawnTime;

    // 두더지 등장 확률 (Normal: 85%, Red: 10%, Blue: 5%)
    private int[] spawnPercents = new int[3] { 85, 10, 5 };
    // 한번에 등장하는 최대 두더지 수
    public int MaxSpawnMole { set; get; } = 1;

    public void Setup()
    {
        StartCoroutine("SpawnMole");
    }

    private IEnumerator SpawnMole()
    {
        while (true)
        {
            // int index = Random.Range(0, moles.Length);

            // 랜덤 타입 설정
            // moles[index].MoleType = SpawnMoleType();

            // 두더지 상태 변경
            // moles[index].ChangeState(MoleState.MoveUp);

            // MaxSpawnMole 숫자만큼 두더지 등장
            StartCoroutine("SpanwMultiMoles");

            // 다음 스폰까지 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private MoleType SpawnMoleType()
    {
        int percent = Random.Range(0, 100);
        float cumulative = 0;

        for (int i = 0; i < spawnPercents.Length; ++i)
        {
            cumulative += spawnPercents[i];

            if (percent < cumulative)
            {
                return (MoleType)i; // 인덱스에 맞는 MoleType 반환
            }
        }

        return MoleType.Normal; // 기본값으로 Normal 반환
    }

    private IEnumerator SpanwMultiMoles()
    {
        int[] indexs = RandomNumerics(moles.Length, moles.Length);
        int currentSpawnMole = 0;
        int curretIndex = 0;

        while (curretIndex < indexs.Length)
        {
            if (moles[indexs[curretIndex]].MoleState == MoleState.UnderGround)
            {
                moles[indexs[curretIndex]].MoleType = SpawnMoleType();
                moles[indexs[curretIndex]].ChangeState(MoleState.MoveUp);
                currentSpawnMole++;

                yield return new WaitForSeconds(0.1f);
            }

            if (currentSpawnMole == MaxSpawnMole)
            {
                break;
            }

            curretIndex++;
            yield return null;
        }
    }

    //0 ~ maxCount까지의 숫자 중 겹치지 않는 n개의 난수생성 메서드
    private int[] RandomNumerics(int maxCount, int n)
    {
        int[] defaults = new int[maxCount];
        int[] results = new int[n];

        for (int i = 0; i < maxCount; i++)
        {
            defaults[i] = i;
        }

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, maxCount);

            results[i] = defaults[index];
            defaults[index] = defaults[maxCount - 1];

            maxCount--;
        }

        return results;
    }
}
