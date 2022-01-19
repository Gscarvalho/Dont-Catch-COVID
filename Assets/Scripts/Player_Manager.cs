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
    private Collider2D playerCollider;

    void Start() {
        playerHP = 5;
        playerVP = 0;
    }
    
    void Update() {
        publicHP = playerHP;
        publicVP = playerVP;
        #region FOR DEBUG
        if(Input.GetKeyDown(KeyCode.H)){
            Debug.Log(publicHP);
        }
        if(Input.GetKeyDown(KeyCode.V)){
        Debug.Log(publicVP);
        }
#endregion
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("FTM")){
            playerVP += 1;
            Debug.Log (publicVP);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("COVID")){
            playerAnim.SetTrigger("isDamaged");
            playerHP -= 1;
            Debug.Log (publicHP);
            Destroy(other.gameObject,0.3f);
        }
    }
}
