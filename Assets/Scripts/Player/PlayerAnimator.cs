using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] PlayerAttackCollision attackCollision;
    [SerializeField]PlayerGuardCollision guardCollision;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMovement(float horizontal,float vertical)
    {
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
    }

    public void OnGuard(bool isGuard)
    {
        animator.SetBool("isGuard", isGuard);
        if (isGuard)
            guardCollision.OnCollision();
    }

    public void OnWeaponAttack()
    {
        animator.SetTrigger("onWeaponAttack");
    }

    public void OnAttackCollision()
    {
        attackCollision.OnCollision();
    }

    public void OffAttackCollosion()
    {
        attackCollision.OffCollision();
    }

    public void OnDodge(float horizontal, float vertical)
    {
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetTrigger("onDodge");
    }
}
