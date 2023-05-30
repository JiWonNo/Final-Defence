using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;                                        //싱글턴
   
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("두개 이상의 BuildManager 가 존재합니다");
        }
        instance = this;
    }

    public bool Canbuild { get { return turretToBuild != null; } }              //속성 설정 함수
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    

    public void SelctNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelcetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        

        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }


}
