using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target; // 플레이어의 Transform
    public float chaseRange = 10f; // 좀비가 플레이어를 감지하는 범위
    private bool isChasing = false; // 추적 상태를 저장하는 변수

    Animator anim;
    NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // 좀비와 플레이어 사이의 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        // 플레이어가 감지 범위 안에 최초로 들어오면 추적 시작
        if (distanceToPlayer <= chaseRange && !isChasing)
        {
            isChasing = true; // 한 번 감지되면 계속 추적
        }

        // isChasing이 true인 상태에서는 감지 범위를 벗어나더라도 계속 추적
        if (isChasing)
        {
            nav.SetDestination(target.position);
            anim.SetBool("isWalk", true); // 걷는 애니메이션 활성화
        }
        else
        {
            nav.ResetPath(); // 추적 중지 (대기 상태)
            anim.SetBool("isWalk", false); // 걷는 애니메이션 비활성화
        }
    }
}
