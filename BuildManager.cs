using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;                                        //�̱���
   
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("�ΰ� �̻��� BuildManager �� �����մϴ�");
        }
        instance = this;
    }

    public bool Canbuild { get { return turretToBuild != null; } }              //�Ӽ� ���� �Լ�
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
