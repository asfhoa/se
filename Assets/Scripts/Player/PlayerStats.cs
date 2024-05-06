using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public float maxHp = 100;   //�ִ� ü��
    public float hp = 100;      //���� ü��
    public float maxStamina=100;   //�ִ� ���׹̳�
    public float stamina = 100;    //���� ���׹̳�
    public float attack = 0;   //���ݷ�
    public float defense = 0;   //����
    public float speed = 5;     //�̵� �ӵ�
    public float dodgeSpeed = 2;   //ȸ�� �ӵ� ����
    public float dodgeTime = 0.5f; //ȸ�� �ð�
    public float blockTime = 0.5f; //�и� �ð�
    public float staminaRecoveryTime = 1.0f; //���� ȸ�� �ð�
    public float attackDelayTime = 0.5f;    //���� ������ �ð�
}
