using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI timeTMP;
    [SerializeField] private Player_Manager player_Manager;
    [SerializeField] private Level_Manager level_Manager;
    void LateUpdate() {
        scoreTMP.text = player_Manager.publicVP.ToString("0");
        timeTMP.text = level_Manager.publicTime.ToString("00");        
    }
}
