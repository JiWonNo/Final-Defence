using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public TextMeshProUGUI life_Text;

    
    void Update()
    {
        life_Text.text = PlayerStats.lifes.ToString();
    }
}
