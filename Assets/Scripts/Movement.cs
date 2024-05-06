using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float gravity;

    Vector3 moveDirection;

    CharacterController controller;
    
    public Vector3 moveVector { get => moveDirection; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //�߷� ���� �÷��̾ ���� ��� ���� �ʴٸ�
        //y�� �̵����⿡ gravity * Time.deltaTime�� �����ش�
        if (!controller.isGrounded==false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void Move(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }
}
