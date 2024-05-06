using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]Transform target; //플레이어를 찾기 위한 변수. 타겟을 찾아서 넣어주는 걸로 수정 예정

    Animator animator; 
    SkinnedMeshRenderer meshRenderer;   //피격시 색상 변경을 위한 렌더러
    NavMeshAgent navMeshAgent;  //네비게이션 에이전트

    Color originColor;      //기본 색상

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //플레이어를 향해 이동
        if (target != null)
            navMeshAgent.SetDestination(target.position);
    }

    public void TakeDamage(int damage)
    {
        //체력이 감소되거나 피격 애니메이션이 재생되는 등의 코드를 작성
        Debug.Log($"{damage}만큼의 체력이 감소합니다");
        //피격 애니메이션 재생
        animator.SetTrigger("onHit");
        //임시로 색이 변하게 만든코드 피격시 추가로 효과를 넣고 싶다면 바꿔서 사용
        StartCoroutine(IEOnHitColor());   
    }

    public void AttackBlocked()
    {
        Debug.Log("공격이 막혔습니다. 무기가 튕기는 모션이 있다면 넣어주세요");
    }

    private IEnumerator IEOnHitColor()
    {
        //색을 빨간색으로 변경한 후 0.1초 후에 원래 색상으로 변경
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
}
