using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level_Manager : MonoBehaviour
{
    public float publicTime;
    private bool gameIsPlaying;
    [SerializeField] private Objects_Builder Objects_Builder;
    [SerializeField] private Player_Controller player_Controller;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject vpTMP;
    [SerializeField] private GameObject vpTitleTMP;    

    private void Start() {
        publicTime = 10;
    }
    private void Update() {
        if(publicTime > 0) {
            publicTime -= Time.deltaTime;
        }else{
            StopGame(0);
            ShowScore();
        }
    }
    void StopGame(float s) {
        publicTime = s;
        Objects_Builder.CancelInvoke();
        player_Controller.enabled = false;
    } 
    void ShowScore() {
        Animator anim = vpTMP.GetComponent<Animator>();
        TextMeshProUGUI text = vpTitleTMP.GetComponent<TextMeshProUGUI>();
        anim.SetTrigger("gameEnd");
        text.text = "Final<br>Score";
    }
}
