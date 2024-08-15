using UnityEngine;

public class PlayerBaseController : BaseController
{
    private void Start()
    {
        base.isPlayerBase = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            SpawnUnit(swordManPrefab);
    }

    private void SpawnUnit(GameObject unitPrefab)
    {
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