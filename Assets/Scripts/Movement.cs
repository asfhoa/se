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
        //중력 설정 플레이어가 땅을 밝고 잇지 않다면
        //y축 이동방향에 gravity * Time.deltaTime을 더해준다
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
