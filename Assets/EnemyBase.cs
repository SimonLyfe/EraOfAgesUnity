using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Base
{
    void Start()
    {
        base.body = body;
        base.health = health;
    }

    void Update()
    {

    }
}
