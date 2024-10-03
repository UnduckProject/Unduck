using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target; // �÷��̾��� Transform
    public float chaseRange = 10f; // ���� �÷��̾ �����ϴ� ����
    private bool isChasing = false; // ���� ���¸� �����ϴ� ����

    Animator anim;
    NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // ����� �÷��̾� ������ �Ÿ� ���
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        // �÷��̾ ���� ���� �ȿ� ���ʷ� ������ ���� ����
        if (distanceToPlayer <= chaseRange && !isChasing)
        {
            isChasing = true; // �� �� �����Ǹ� ��� ����
        }

        // isChasing�� true�� ���¿����� ���� ������ ������� ��� ����
        if (isChasing)
        {
            nav.SetDestination(target.position);
            anim.SetBool("isWalk", true); // �ȴ� �ִϸ��̼� Ȱ��ȭ
        }
        else
        {
            nav.ResetPath(); // ���� ���� (��� ����)
            anim.SetBool("isWalk", false); // �ȴ� �ִϸ��̼� ��Ȱ��ȭ
        }
    }
}
