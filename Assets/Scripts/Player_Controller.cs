using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float input;
    
    [SerializeField] private float speed;    
    [SerializeField] private SpriteRenderer playerSR;

    void Update() {
        input = Input.GetAxisRaw("Horizontal");
        if(input >= 1) {
            playerSR.flipX = true;
        }
        if(input <= -1) {
            playerSR.flipX = false;
        }
    }

    void FixedUpdate() {
        if(input != 0) {
            transform.Translate(Vector3.right * input * speed * Time.deltaTime);            
        }
    }
}
