using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;        //최초에 카메라의 위치를 설정할때 사용.
    [SerializeField] float xMoveSpeed;      //y축 이동 속도.
    [SerializeField] float yMoveSpeed;      //x축 이동 속도.
    [SerializeField] float yMinLimit;       //x축 최소 각도.
    [SerializeField] float yMaxLimit;       //x축 최대 각도.
    float x, y;                             //마우스 이동 값.
    float distance;                         //카메라와 플레이어 사이의 거리.

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
        if(target == null)  //타겟이 없으면 넘긴다
            return;

        //마우스를 움직였을때의 값으로 x, y값을 변경한다.
        x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;
        //오브젝트의 위/아래(x축) 한계 범위 설정
        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        //카메라의 회전(rotation)정보 갱신
        transform.rotation = Quaternion.Euler(y, x, 0);
    }

    private void LateUpdate()
    {
        if (target == null)  //타겟이 없으면 넘긴다
            return;

        transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;
    }
}
