using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float input;
    [SerializeField] private float speed;
    void Start() {
        
    }

    void Update() {
        input = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate() {
        if(input != 0) {
            transform.Translate(Vector3.right * input * speed * Time.deltaTime);
        }
    }
}
