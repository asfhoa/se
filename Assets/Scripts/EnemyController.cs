using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]Transform target; //�÷��̾ ã�� ���� ����. Ÿ���� ã�Ƽ� �־��ִ� �ɷ� ���� ����

    Animator animator; 
    SkinnedMeshRenderer meshRenderer;   //�ǰݽ� ���� ������ ���� ������
    NavMeshAgent navMeshAgent;  //�׺���̼� ������Ʈ

    Color originColor;      //�⺻ ����

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //�÷��̾ ���� �̵�
        if (target != null)
            navMeshAgent.SetDestination(target.position);
    }

    public void TakeDamage(int damage)
    {
        //ü���� ���ҵǰų� �ǰ� �ִϸ��̼��� ����Ǵ� ���� �ڵ带 �ۼ�
        Debug.Log($"{damage}��ŭ�� ü���� �����մϴ�");
        //�ǰ� �ִϸ��̼� ���
        animator.SetTrigger("onHit");
        //�ӽ÷� ���� ���ϰ� �����ڵ� �ǰݽ� �߰��� ȿ���� �ְ� �ʹٸ� �ٲ㼭 ���
        StartCoroutine(IEOnHitColor());   
    }

    public void AttackBlocked()
    {
        Debug.Log("������ �������ϴ�. ���Ⱑ ƨ��� ����� �ִٸ� �־��ּ���");
    }

    private IEnumerator IEOnHitColor()
    {
        //���� ���������� ������ �� 0.1�� �Ŀ� ���� �������� ����
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
}
