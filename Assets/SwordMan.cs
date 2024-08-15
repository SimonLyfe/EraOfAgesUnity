using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMan : Unit
{
    void Start()
    {
        base.speed = speed;
        base.health = health;
        base.damage = damage;
        base.attackRange = attackRange;
        base.attackSpeed = attackSpeed;
        base.cost = cost;
    }
}
