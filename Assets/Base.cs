using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public Rigidbody2D body;
    public int health;

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            
        }
    }
}
