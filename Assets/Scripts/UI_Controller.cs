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
    [SerializeField] private RectTransform ftmIcon;
    void LateUpdate() {
        scoreTMP.text = player_Manager.playerVP.ToString("0");
        timeTMP.text = level_Manager.publicTime.ToString("00");
        if(player_Manager.playerVP >= 10){
            ftmIcon.anchoredPosition3D = new Vector3(37,-31,0);
        }
    }
}
