using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;

    Animator anim;
    Vector3 moveVec;
    Rigidbody rigid;

    float hor;
    float ver;
    bool isWalk;
    bool isJump;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputKey();
        Move();
        Turn();
    }

    private void InputKey()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        isWalk = Input.GetButton("Walk");
        isJump = Input.GetButtonDown("Spacebar");
    }

    private void Move()
    {
        moveVec = new Vector3(hor, 0, ver).normalized;

        anim.SetBool("isWalk", moveVec != Vector3.zero && isWalk);
        anim.SetBool("isRun", moveVec != Vector3.zero);

        transform.position += moveVec * speed * (isWalk ? 0.5f : 1f) * Time.deltaTime;
    }

    private void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    private void Jump()
    {
        if (isJump)
        {
            rigid.AddForce(Vector3.up * 3,ForceMode.Impulse);
        }
    }
}
