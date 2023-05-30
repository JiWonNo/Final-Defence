using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint ballistaTower;
    public TurretBlueprint fireTower;
    public TurretBlueprint laserTower;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectBallistaTower()
    {
        Debug.Log("Ballista Tower Selected");
        buildManager.SelcetTurretToBuild(ballistaTower);
    }

    public void SelectFireTower()
    {
        Debug.Log("Fire Tower Selected");
        buildManager.SelcetTurretToBuild(fireTower);
    }
    public void SelectLaserTower()
    {
        Debug.Log("Laser Tower Selected");
        buildManager.SelcetTurretToBuild(laserTower);
    }


}
