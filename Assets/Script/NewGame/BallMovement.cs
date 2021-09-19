using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{   
    public ScoreManager score;
    public float speed = 10;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        AddStartingForce();
    }

    void AddStartingForce(){
        float x = Random.value;
        float y = Random.value;

        Vector2 direction = new Vector2(x,y);
        rigidbody2D.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force){
        rigidbody2D.AddForce(force);
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Paddle")){
            score.AddScore();
        }
    }
}
