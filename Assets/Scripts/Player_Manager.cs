using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public float publicHP;
    public float publicVP;
    private float playerHP;
    private float playerVP;

    [SerializeField] private Animator playerAnim;

    void Start() {
        playerHP = 5;
        playerVP = 0;
    }
    
    void Update() {
        publicHP = playerHP;
        publicVP = playerVP;
        if(Input.GetKeyDown(KeyCode.H)){
            Debug.Log(publicHP);
        }
        if(Input.GetKeyDown(KeyCode.V)){
        Debug.Log(publicVP);
        }
        if(Input.GetKeyDown(KeyCode.A)){
            playerHP -= 1;
            playerAnim.SetTrigger("isDamaged");
        }
    }


}
