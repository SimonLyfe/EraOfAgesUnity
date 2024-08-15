using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Unit : MonoBehaviour
{
    public Base unitBase;
    public Rigidbody2D body;
    public BaseController baseController;

    public bool isPlayerUnit;

    public bool isAlive = true;

    public float speed; 
    public int health; 
    public int damage;
    public float attackRange;
    public float attackSpeed;
    public float cost;

    public bool shouldMove = true;
    public bool hasTarget = false;

    public void Initialize()
    {
        isPlayerUnit = baseController.isPlayerBase;
        if (!isPlayerUnit)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void Move()
    {
        float direction = isPlayerUnit ? 1f : -1f; // Move right if player, left if enemy
        Vector2 movement = new Vector2(speed * direction, 0);
        body.velocity = movement;
    }
}
