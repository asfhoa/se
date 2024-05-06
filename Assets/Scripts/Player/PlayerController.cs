using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode dodgeKey = KeyCode.Space;  //ȸ�� Ű
    [SerializeField] Transform cameraTransform;
    
    Movement movement;                //characterController�� �����ϴ� ��ũ��Ʈ
    PlayerAnimator playerAnimator;    //�ִϸ��̼��� �����ϴ� ��ũ��Ʈ

    Vector3 dodgeVec;       //ȸ���Ҷ� �̵� ������ ����

    bool onDodge = false;           //ȸ�� Ű�� �Է�������
    bool onWeaponAttack = false;    //���� Ű�� �Է�������
    bool isDodge = false;           //ȸ�� ���϶�
    bool isGuard = false;           //���� ���϶�

    float x;
    float z;

    private void Awake()
    {
        Cursor.visible = false;                     //���콺 Ŀ�� ����
        Cursor.lockState = CursorLockMode.Locked;   //���콺 Ŀ�� ��ġ ����
        movement = GetComponent<Movement>();      
        playerAnimator = GetComponentInChildren<PlayerAnimator>(); 
    }

    private void Update()
    {
        InputKey(); //Ű �Է� �Լ� ȣ��
        Move();     //�̵� �Լ� ȣ��
        Dodge();    //ȸ�� �Լ� ȣ��

        if (onWeaponAttack)
            playerAnimator.OnWeaponAttack();    //�ִϸ��̼� ���� ȣ��
        
        playerAnimator.OnGuard(isGuard);   //���� �ִϸ��̼� ȣ��  
    }

    private void InputKey()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        onDodge = Input.GetKeyDown(dodgeKey);
        onWeaponAttack = Input.GetMouseButtonDown(0);   //���콺 ���� ��ư Ŭ��
        isGuard = Input.GetMouseButton(1);              //���콺 ������ ��ư Ŭ��
    }

    private void Attack()
    {

    }

    private void Move()
    {
        //�̵� �Լ� ȣ��(ī�޶� �����ִ� ������ ������ ����Ű�� ���� �̵�)
        movement.Move(cameraTransform.rotation * (!isDodge ? new Vector3(x, 0, z) : dodgeVec));
        //ȸ�� ����(�׻� �ո� ������ ĳ������ ȸ���� ī�޶�� ���� ȸ�� ������ ����)
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        playerAnimator.OnMovement(x, z);   //�ִϸ��̼� �̵� ȣ��
    }

    private void Dodge()
    {
        if (onDodge && movement.moveVector != Vector3.zero && !isDodge)
        {
            isDodge = true;
            movement.MoveSpeed *= 2f;
            dodgeVec = new Vector3(x, 0, z);
            playerAnimator.OnDodge(dodgeVec.x, dodgeVec.z);
            Invoke("DodgeOut", 0.5f);
        }
    }

    private void DodgeOut()     //ȸ�ǰ� ������ ȣ��
    {
        isDodge = false;
        movement.MoveSpeed *= 0.5f;
    }
}
