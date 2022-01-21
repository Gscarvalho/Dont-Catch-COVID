using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] private Objects_Builder objects_Builder;
    [SerializeField] private Player_Controller player_Controller;
    [SerializeField] private Player_Manager player_Manager;
    [Space]
    [SerializeField] private Animator gameMessageAnim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips = new AudioClip[0];
    [Space]
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject winMessage;
    [SerializeField] private GameObject loseMessage;
    [SerializeField] private GameObject loseTimeMessage;
    [Space]
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject vpTMP;
    [SerializeField] private GameObject vpTitleTMP;  
    public bool gameOver = false; 
    public float publicTime = 10;

    private void OnEnable() {
        publicTime = 10;
    }
    private void Update() {
        if (tutorial.activeInHierarchy == false && publicTime > 0 && !gameOver) {
            publicTime -= Time.deltaTime;
            Debug.Log("COUNTING DOWN");
        }        
        if(publicTime <= 0) {
            gameOver = true;
            StopGame();
            ShowScore();
            if(player_Manager.playerVP > 0) {           
                ShowMessage(winMessage);
                if(audioSource.clip != clips[1]) {
                    audioSource.Stop();
                    audioSource.clip = clips[1];
                    audioSource.Play();
                }   
            }else{
                ShowMessage(loseTimeMessage);
                if(audioSource.clip != clips[0]) {
                audioSource.Stop();
                audioSource.clip = clips[0];
                audioSource.Play();
            }
            }
            Debug.Log("A");
        }
        if(player_Manager.publicHP <= 0 && publicTime > 0) {
            if(audioSource.clip != clips[0]) {
                audioSource.Stop();
                audioSource.clip = clips[0];
                audioSource.Play();
            }
            gameOver = true;
            StopGame();
            player_Manager.playerVP = 0;
            ShowScore();
            ShowMessage(loseMessage); 
            Debug.Log("B");
        }       
        if(Input.GetKeyDown(KeyCode.Escape)){
            ExitGame();
        }
    }
    void StopGame() {
        objects_Builder.CancelInvoke();
        player_Controller.enabled = false;
        player_Manager.enabled = false;
        gameOver = true;
        Debug.Log("C");
    } 
    void ShowScore() {
        Animator anim = vpTMP.GetComponent<Animator>();
        TextMeshProUGUI text = vpTitleTMP.GetComponent<TextMeshProUGUI>();
        anim.SetTrigger("gameEnd");
        gameMessageAnim.SetTrigger("showMessage");        
        text.text = "Final<br>Score";        
    }
    void ShowMessage(GameObject o) {
        o.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
    }
    public void ExitGame() {
        Application.Quit();
    }
    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}
