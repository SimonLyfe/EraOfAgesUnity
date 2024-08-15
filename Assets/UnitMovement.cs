using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public void Move(Unit unit)
    {
        Vector2 speed = new Vector2(unit.speed, 0);
        if (unit.body != null)
        {
            unit.body.velocity = speed;
        }
    }
}
