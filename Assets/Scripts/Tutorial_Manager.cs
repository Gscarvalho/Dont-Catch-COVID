using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Manager : MonoBehaviour
{
    [SerializeField] private Level_Manager level_Manager;
    private void Start() {
        StartCoroutine(StartGame(2));
    }    
    IEnumerator StartGame(float s) {
        yield return new WaitForSeconds(s);
        level_Manager.enabled = true;
        gameObject.SetActive(false);
    }
}
