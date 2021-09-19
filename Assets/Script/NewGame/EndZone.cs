using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public GameObject GameOverText;
    public AnalyticManager analyticManager;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ball")){
            analyticManager.LogData(other.gameObject.GetComponent<BallMovement>().score.score,Time.time);

            analyticManager.LogCustom(other.gameObject.GetComponent<BallMovement>().score.score,Time.time);

            Destroy(other.gameObject);
            GameOverText.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
