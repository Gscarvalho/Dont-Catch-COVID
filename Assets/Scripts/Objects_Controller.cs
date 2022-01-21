using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects_Controller : MonoBehaviour
{
    private float posY;
    private Rigidbody2D rb;
    private float f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        f = Random.Range(0.8f,2);
    }

    void Update() {
        posY = this.transform.position.y;
        rb.AddForce(Vector2.down * f);
        if(posY <= -6.5) {
            Destroy(gameObject);
        }
    }
}
