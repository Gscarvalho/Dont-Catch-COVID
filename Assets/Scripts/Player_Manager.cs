using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Manager : MonoBehaviour
{
    public float publicHP;    
    private float playerHP;
    [HideInInspector]public float playerVP;

    [SerializeField] private GameObject HPObject;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Animator camAnim;
    private Collider2D playerCollider;
    private RectTransform HP;
    private RawImage HPimage;

    void Start() {
        playerHP = 3;
        playerVP = 0;
        HP = HPObject.GetComponent<RectTransform>();
        HPimage = HPObject.GetComponent<RawImage>();
    }
    
    void Update() {
        HP.localScale = new Vector3(playerHP*2,1,1);

        if(playerHP == 3) {
            HPimage.color = new Color32(0,188,255,255);
        }if(playerHP == 2) {
            HPimage.color = new Color32(255,164,0,255);
        }if(playerHP <= 1){
            HPimage.color = new Color32(255,0,4,255);
        }
        publicHP = playerHP;

    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("FTM")){
            playerVP += 1;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("COVID")){
            playerAnim.SetTrigger("isDamaged");
            playerHP -= 1;
            camAnim.SetTrigger("shakeCam");
            Destroy(other.gameObject,0.3f);
        }
    }
}
