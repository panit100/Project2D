using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 250;
    public float speed = 5;

    bool jump = false;
    bool ground = false;
    public bool goLeft = false;
    public bool goRight = false;

    public bool getkey = false;

    Rigidbody2D rigidbody;
    Light2D light;
    JsonManager jsonManager;
    

    // Start is called before the first frame update
    void Start()
    {
        jsonManager = FindObjectOfType<JsonManager>();
        light = GetComponent<Light2D>();
        rigidbody = GetComponent<Rigidbody2D>();    

        jsonManager.LoadJson();
        light.color = jsonManager.colorData.playerColor;

    }

    // Update is called once per frame
    public void Jumping()
    {
        if(ground){
            jump = true;
            ground = false;
        }
    }
    
    private void FixedUpdate() {
        MoveLeft();
        MoveRight();
        Jump();
    }

    public void MoveLeft(){
        if(goLeft){
            rigidbody.velocity = new Vector2(-(speed), rigidbody.velocity.y);
        }
    }
    public void MoveRight(){
        if(goRight){
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }
    }

    void Jump(){
        if(jump){
            rigidbody.AddForce(new Vector2(0f,jumpForce));
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            ground = true;
        }
        
        
    }
}
