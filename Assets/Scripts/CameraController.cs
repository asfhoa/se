using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;        //���ʿ� ī�޶��� ��ġ�� �����Ҷ� ���.
    [SerializeField] float xMoveSpeed;      //y�� �̵� �ӵ�.
    [SerializeField] float yMoveSpeed;      //x�� �̵� �ӵ�.
    [SerializeField] float yMinLimit;       //x�� �ּ� ����.
    [SerializeField] float yMaxLimit;       //x�� �ִ� ����.
    float x, y;                             //���콺 �̵� ��.
    float distance;                         //ī�޶�� �÷��̾� ������ �Ÿ�.

    private void Awake()
    {
        transform.position = Vector3.zero + offset;
        distance = Vector3.Distance(transform.position, target.position);
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void Update()
    {
        if(target == null)  //Ÿ���� ������ �ѱ��
            return;

        //���콺�� ������������ ������ x, y���� �����Ѵ�.
        x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;
        //������Ʈ�� ��/�Ʒ�(x��) �Ѱ� ���� ����
        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        //ī�޶��� ȸ��(rotation)���� ����
        transform.rotation = Quaternion.Euler(y, x, 0);
    }

    private void LateUpdate()
    {
        if (target == null)  //Ÿ���� ������ �ѱ��
            return;

        transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;
    }
}
