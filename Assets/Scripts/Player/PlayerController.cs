using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] KeyCode dodgeKey = KeyCode.Space;  //회피 키
    [SerializeField] Transform cameraTransform;
    
    Movement movement;                //characterController를 조종하는 스크립트
    PlayerAnimator playerAnimator;    //애니메이션을 조종하는 스크립트

    Vector3 dodgeVec;       //회피할때 이동 방향을 저장

    bool onDodge = false;           //회피 키를 입력했을때
    bool onWeaponAttack = false;    //공격 키를 입력했을때
    bool isDodge = false;           //회피 중일때
    bool isGuard = false;           //가드 중일때

    float x;
    float z;

    private void Awake()
    {
        Cursor.visible = false;                     //마우스 커서 숨김
        Cursor.lockState = CursorLockMode.Locked;   //마우스 커서 위치 고정
        movement = GetComponent<Movement>();      
        playerAnimator = GetComponentInChildren<PlayerAnimator>(); 
    }

    private void Update()
    {
        InputKey(); //키 입력 함수 호출
        Move();     //이동 함수 호출
        Dodge();    //회피 함수 호출

        if (onWeaponAttack)
            playerAnimator.OnWeaponAttack();    //애니메이션 공격 호출
        
        playerAnimator.OnGuard(isGuard);   //가드 애니메이션 호출  
    }

    private void InputKey()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        onDodge = Input.GetKeyDown(dodgeKey);
        onWeaponAttack = Input.GetMouseButtonDown(0);   //마우스 왼쪽 버튼 클릭
        isGuard = Input.GetMouseButton(1);              //마우스 오른쪽 버튼 클릭
    }

    private void Attack()
    {

    }

    private void Move()
    {
        //이동 함수 호출(카메라 보고있는 방향을 기준을 방향키에 따라 이동)
        movement.Move(cameraTransform.rotation * (!isDodge ? new Vector3(x, 0, z) : dodgeVec));
        //회전 설정(항상 앞만 보도록 캐릭터의 회전은 카메라와 같은 회전 값으로 설정)
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        playerAnimator.OnMovement(x, z);   //애니메이션 이동 호출
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

    private void DodgeOut()     //회피가 끝나면 호출
    {
        isDodge = false;
        movement.MoveSpeed *= 0.5f;
    }
}
