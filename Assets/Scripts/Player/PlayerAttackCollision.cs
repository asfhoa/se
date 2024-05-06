using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    BoxCollider attackCollider;

    private void Awake()
    {
        attackCollider = GetComponent<BoxCollider>();
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(10);
        }
    }

    public void OnCollision()
    {
        attackCollider.enabled = true;
    }
    public void OffCollision()
    {
        attackCollider.enabled = false;
    }
}
