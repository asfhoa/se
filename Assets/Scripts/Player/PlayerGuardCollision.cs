using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuardCollision : MonoBehaviour
{
    BoxCollider guardCollider;

    private void Awake()
    {
        guardCollider = GetComponent<BoxCollider>();
        guardCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().AttackBlocked();
        }
    }

    private IEnumerator IEAutoDisable()
    {
        //0.1�� �Ŀ� ������Ʈ�� ��������� �Ѵ�
        yield return new WaitForSeconds(0.1f);

        guardCollider.enabled = false;
    }

    IEnumerator currentCoroutine;
    public void OnCollision()
    {
        guardCollider.enabled = true;
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = IEAutoDisable();
        StartCoroutine(currentCoroutine);
    }
}
