using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseController : BaseController
{
    public GameObject unitPrefab; // The unit prefab to spawn
    public float spawnInterval = 5f; // Interval in seconds between spawns

    void Start()
    {
        base.isPlayerBase = false;

        StartCoroutine(SpawnUnits());
    }

    private IEnumerator SpawnUnits()
    {
        while (true) 
        {
            float randomInterval = spawnInterval + Random.Range(-1f, 2f);
            yield return new WaitForSeconds(randomInterval);
            GameObject newUnit = Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
            Unit unitComponent = newUnit.GetComponent<Unit>();
            if (unitComponent)
            {
                unitComponent.baseController = this; // Set the base reference
                unitComponent.Initialize();
                unitManager.AddUnit(unitComponent);
            }
        }
    }
}
