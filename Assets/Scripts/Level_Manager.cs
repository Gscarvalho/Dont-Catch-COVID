using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects = new GameObject[0];
    [SerializeField] private float respawnRate;
    [HideInInspector] public Vector3 position;

    private void Start() {
        InvokeRepeating("MakeObjects",1,respawnRate);
    }
    
    void MakeObjects() {
        position.x = Random.Range(-8,8);
        position.y = 8;
        position.z = 0;

        Instantiate(objects[Random.Range(0,objects.Length)],position,Quaternion.identity);        
    }
}
