
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSO", menuName = "SO/MonsterSO", order = 1)]
public class MonsterSO : ScriptableObject
{
    public int hp;
    public int attack;
    public float attackSpeed;
    public int addCost;
    public float speed;
    public bool isFly;
}
