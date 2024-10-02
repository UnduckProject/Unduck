// using System.Collections;
// using UnityEngine;

// public enum MoleState { UnderGround = 0, OnGround, MoveUp, MoveDown}
// public enum MoleType { Normal = 0, Red, Blue}

// public class MoleFSM : MonoBehaviour
// {
//     [SerializeField]
//     private GameController gameController;
//     [SerializeField]
//     private float waitTimeOnGround;
//     [SerializeField]
//     private float limitMinY;
//     [SerializeField]
//     private float limitMaxY;

//     private Movement3D movement3D;
//     private MeshRenderer meshRenderer;

//     private MoleType moleType;
//     private Color defaultColor;

//     public MoleState MoleState { private set; get; }
//     public MoleType MoleType
//     {
//         set
//         {
//             moleType = value;

//             switch (moleType)
//             {
//                 case MoleType.Normal:
//                     meshRenderer.material.color = defaultColor;
//                     break;
//                 case MoleType.Red:
//                     meshRenderer.material.color = Color.red;
//                     break;
//                 case MoleType.Blue:
//                     meshRenderer.material.color = Color.blue;
//                     break;
//             }
//         }
//         get => moleType;
//     }

//     [field: SerializeField]
//     public int MoleIndex { private set; get; }

//     private void Awake()
//     {
//         movement3D = GetComponent<Movement3D>();
//         meshRenderer = GetComponent<MeshRenderer>();

//         defaultColor = meshRenderer.material.color;

//         ChangeState(MoleState.UnderGround);
//     }

//     public void ChangeState(MoleState newState)
//     {
//         StopCoroutine(MoleState.ToString());
//         MoleState = newState;
//         StartCoroutine(MoleState.ToString());
//     }

//     private IEnumerator UnderGround()
//     {
//         movement3D.MoveTo(Vector3.zero);
//         transform.position = new Vector3(transform.position.x, limitMinY, transform.position.z);

//         yield return null;
//     }

//     private IEnumerator OnGround()
//     {
//         movement3D.MoveTo(Vector3.zero);
//         transform.position = new Vector3(transform.position.x, limitMaxY, transform.position.z);
//         yield return new WaitForSeconds(waitTimeOnGround);
//         ChangeState(MoleState.MoveDown);
//     }

//     private IEnumerator MoveUp()
//     {
//         movement3D.MoveTo(Vector3.up);

//         while (true)
//         {
//             if(transform.position.y >= limitMaxY)
//             {
//                 ChangeState(MoleState.OnGround);
//             }

//             yield return null;
//         }
//     }

//     private IEnumerator MoveDown()
//     {
//         movement3D.MoveTo(Vector3.down);

//         while (true)
//         {
//             if(transform.position.y <= limitMinY)
//             {
//                 // ChangeState(MoleState.UnderGround);
//                 break;
//             }

//             yield return null;
//         }

//         if (moleType == MoleType.Normal)
//         {
//             gameController.Combo = 0;
//         }

//         ChangeState(MoleState.UnderGround);
//     }
// }
using System.Collections;
using UnityEngine;

public enum MoleState { UnderGround = 0, OnGround, MoveUp, MoveDown }
public enum MoleType { Normal = 0, Red, Blue }

public class MoleFSM : MonoBehaviour
{
    [SerializeField]
    private GameController gameController; // Inspector에서 할당할 수 있도록 남겨두기
    [SerializeField]
    private float waitTimeOnGround;
    [SerializeField]
    private float holeOffsetDown = -0.3f; // Hole 아래로 이동할 오프셋
    [SerializeField]
    private float holeOffsetUp = 0.1f; // Hole 위로 이동할 오프셋

    private Movement3D movement3D;
    private MeshRenderer meshRenderer;

    private MoleType moleType;
    private Color defaultColor;

    public MoleState MoleState { private set; get; }
    public MoleType MoleType
    {
        set
        {
            moleType = value;

            switch (moleType)
            {
                case MoleType.Normal:
                    meshRenderer.material.color = defaultColor;
                    break;
                case MoleType.Red:
                    meshRenderer.material.color = Color.red;
                    break;
                case MoleType.Blue:
                    meshRenderer.material.color = Color.blue;
                    break;
            }
        }
        get => moleType;
    }

    [field: SerializeField]
    public int MoleIndex { private set; get; }

    private Transform holeTransform; // Hole 오브젝트의 Transform

    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        meshRenderer = GetComponent<MeshRenderer>();

        defaultColor = meshRenderer.material.color;

        // GameController를 찾기
        if (gameController == null)
        {
            gameController = FindObjectOfType<GameController>(); // GameController를 찾음
            if (gameController == null)
            {
                Debug.LogWarning("GameController를 찾을 수 없습니다. MoleFSM이 제대로 작동하지 않을 수 있습니다.");
            }
        }

        // Hole 오브젝트를 찾기
        Transform holesParent = GameObject.Find("SpawnGame/Game(Clone)/Holes")?.transform; // Holes 폴더 찾기
        if (holesParent != null)
        {
            // Holes 폴더 내의 모든 Hole 오브젝트를 찾고, 첫 번째 Hole을 사용
            if (holesParent.childCount > 0)
            {
                holeTransform = holesParent.GetChild(0); // 첫 번째 Hole을 참조
            }
            else
            {
                Debug.LogWarning("Holes 폴더에 Hole 오브젝트가 없습니다.");
            }
        }
        else
        {
            Debug.LogWarning("Holes 폴더를 찾을 수 없습니다.");
        }

        ChangeState(MoleState.UnderGround);
    }

    public void ChangeState(MoleState newState)
    {
        StopCoroutine(MoleState.ToString());
        MoleState = newState;
        StartCoroutine(MoleState.ToString());
    }

    private IEnumerator UnderGround()
    {
        if (holeTransform != null)
        {
            // Hole 위치에서 -0.3 만큼 내려가기
            movement3D.MoveTo(Vector3.zero);
            transform.position = new Vector3(transform.position.x, holeTransform.position.y + holeOffsetDown, transform.position.z);
        }
        yield return null;
    }

    private IEnumerator OnGround()
    {
        if (holeTransform != null)
        {
            // Hole 위치에서 +0.1 만큼 올라오기
            movement3D.MoveTo(Vector3.zero);
            transform.position = new Vector3(transform.position.x, holeTransform.position.y + holeOffsetUp, transform.position.z);
        }
        yield return new WaitForSeconds(waitTimeOnGround);
        ChangeState(MoleState.MoveDown);
    }

    private IEnumerator MoveUp()
    {
        movement3D.MoveTo(Vector3.up);

        while (true)
        {
            if (transform.position.y >= (holeTransform.position.y + holeOffsetUp))
            {
                ChangeState(MoleState.OnGround);
            }

            yield return null;
        }
    }

    private IEnumerator MoveDown()
    {
        movement3D.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= (holeTransform.position.y + holeOffsetDown))
            {
                break;
            }

            yield return null;
        }

        if (moleType == MoleType.Normal && gameController != null)
        {
            gameController.Combo = 0;
        }

        ChangeState(MoleState.UnderGround);
    }
}
