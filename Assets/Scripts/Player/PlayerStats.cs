using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats", order = 1)]
public class PlayerStats : ScriptableObject
{
    public float maxHp = 100;   //최대 체력
    public float hp = 100;      //현재 체력
    public float maxStamina=100;   //최대 스테미나
    public float stamina = 100;    //현재 스테미나
    public float attack = 0;   //공격력
    public float defense = 0;   //방어력
    public float speed = 5;     //이동 속도
    public float dodgeSpeed = 2;   //회피 속도 배율
    public float dodgeTime = 0.5f; //회피 시간
    public float blockTime = 0.5f; //패링 시간
    public float staminaRecoveryTime = 1.0f; //가드 회복 시간
    public float attackDelayTime = 0.5f;    //공격 딜레이 시간
}
