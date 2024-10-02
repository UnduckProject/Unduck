// using System.Collections;
// using UnityEngine;

// public class MoleSpawner : MonoBehaviour
// {
//     [SerializeField]
//     private MoleFSM[] moles;
//     [SerializeField]
//     private float spawnTime;

//     // �δ��� ���� Ȯ�� (Normal: 85%, Red: 10%, Blue: 5%)
//     private int[] spawnPercents = new int[3] { 85, 10, 5 };
//     // �ѹ��� �����ϴ� �ִ� �δ��� ��
//     public int MaxSpawnMole { set; get; } = 1;

//     public void Setup()
//     {
//         StartCoroutine("SpawnMole");
//     }

//     private IEnumerator SpawnMole()
//     {
//         while (true)
//         {
//             // int index = Random.Range(0, moles.Length);

//             // ���� Ÿ�� ����
//             // moles[index].MoleType = SpawnMoleType();

//             // �δ��� ���� ����
//             // moles[index].ChangeState(MoleState.MoveUp);

//             // MaxSpawnMole ���ڸ�ŭ �δ��� ����
//             StartCoroutine("SpanwMultiMoles");

//             // ���� �������� ���
//             yield return new WaitForSeconds(spawnTime);
//         }
//     }

//     private MoleType SpawnMoleType()
//     {
//         int percent = Random.Range(0, 100);
//         float cumulative = 0;

//         for (int i = 0; i < spawnPercents.Length; ++i)
//         {
//             cumulative += spawnPercents[i];

//             if (percent < cumulative)
//             {
//                 return (MoleType)i; // �ε����� �´� MoleType ��ȯ
//             }
//         }

//         return MoleType.Normal; // �⺻������ Normal ��ȯ
//     }

//     private IEnumerator SpanwMultiMoles()
//     {
//         int[] indexs = RandomNumerics(moles.Length, moles.Length);
//         int currentSpawnMole = 0;
//         int curretIndex = 0;

//         while (curretIndex < indexs.Length)
//         {
//             if (moles[indexs[curretIndex]].MoleState == MoleState.UnderGround)
//             {
//                 moles[indexs[curretIndex]].MoleType = SpawnMoleType();
//                 moles[indexs[curretIndex]].ChangeState(MoleState.MoveUp);
//                 currentSpawnMole++;

//                 yield return new WaitForSeconds(0.1f);
//             }

//             if (currentSpawnMole == MaxSpawnMole)
//             {
//                 break;
//             }

//             curretIndex++;
//             yield return null;
//         }
//     }

//     //0 ~ maxCount������ ���� �� ��ġ�� �ʴ� n���� �������� �޼���
//     private int[] RandomNumerics(int maxCount, int n)
//     {
//         int[] defaults = new int[maxCount];
//         int[] results = new int[n];

//         for (int i = 0; i < maxCount; i++)
//         {
//             defaults[i] = i;
//         }

//         for (int i = 0; i < n; i++)
//         {
//             int index = Random.Range(0, maxCount);

//             results[i] = defaults[index];
//             defaults[index] = defaults[maxCount - 1];

//             maxCount--;
//         }

//         return results;
//     }
// }
using System.Collections;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    [SerializeField]
    private MoleFSM[] moles;
    [SerializeField]
    private float spawnTime;

    // 생성 확률 (Normal: 85%, Red: 10%, Blue: 5%)
    private int[] spawnPercents = new int[3] { 85, 10, 5 };
    // 최대 생성할 두더지 수
    public int MaxSpawnMole { set; get; } = 1;

    private void Awake()
    {
        // Mole 오브젝트를 찾는 코루틴 시작
        StartCoroutine(FindMolesCoroutine());
    }

    private IEnumerator FindMolesCoroutine()
    {
        // Game(clone) 오브젝트가 생성될 때까지 대기
        while (true)
        {
            // "SpawnGame" 오브젝트를 찾음
            GameObject spawnGameObject = GameObject.Find("SpawnGame");
            if (spawnGameObject != null)
            {
                // "Game(Clone)" 오브젝트를 찾음
                Transform gameTransform = spawnGameObject.transform.Find("Game(Clone)");
                if (gameTransform != null)
                {
                    // "Mole" 오브젝트를 찾음
                    Transform moleParent = gameTransform.Find("Moles");
                    if (moleParent != null)
                    {
                        // "Mole" 오브젝트 아래의 모든 MoleFSM 컴포넌트를 찾음
                        moles = moleParent.GetComponentsInChildren<MoleFSM>();
                        break; // 찾으면 루프 종료
                    }
                }
            }
            // 잠시 대기 후 다시 확인
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Setup()
    {
        StartCoroutine("SpawnMole");
    }

    private IEnumerator SpawnMole()
    {
        while (true)
        {
            StartCoroutine("SpanwMultiMoles");
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
                return (MoleType)i; // 인덱스에 해당하는 MoleType 반환
            }
        }

        return MoleType.Normal; // 기본값은 Normal 반환
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

    // 0 ~ maxCount까지의 랜덤 인덱스를 n개 생성하는 함수
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
