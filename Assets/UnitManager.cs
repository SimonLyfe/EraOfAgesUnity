using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<Unit> allUnits = new List<Unit>();
    public List<Unit> playerUnits = new List<Unit>();
    public List<Unit> enemyUnits = new List<Unit>();

    void FixedUpdate()
    {
        foreach (Unit unit in allUnits)
        {
            if (unit.isAlive)
            {
                //findTarget(unit);
                if (unit.hasTarget)
                {
                    //unit.Attack();
                }
                else
                {
                    unit.Move();
                }
            }
        }
    }

    public void AddUnit(Unit unit)
    {
        allUnits.Add(unit);
        if (unit.isPlayerUnit)
        {
            playerUnits.Add(unit);
        }
        else
        {
            enemyUnits.Add(unit);   
        }
    }

    public void RemoveUnit(Unit unit)
    {
        allUnits.Remove(unit);
        if (unit.isPlayerUnit)
        {
            playerUnits.Remove(unit);
        }
        else
        {
            enemyUnits.Remove(unit);
        }
    }

    public void FindTarget(Unit unit)
    {

    }
}

