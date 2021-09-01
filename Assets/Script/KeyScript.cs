using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<PlayerController>().getkey = true;
            FindObjectOfType<GoalScript>().ShowMiddleText("Find Hidden Temple");
            Destroy(gameObject);
        }
    }
}
