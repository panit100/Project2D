using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxPosition = 7;
    public float minPosition = -7;
    public float speed = 5;

    protected void ControllerUpDown(){
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    protected void ControllerLeftRight(){
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    protected void UpdatePositionPaddleX(){
        this.transform.position = this.transform.position.x < -7f ? new Vector2(-7,this.transform.position.y) : 
                            this.transform.position.x > 7 ? new Vector2(7,this.transform.position.y) : new Vector2(this.transform.position.x,this.transform.position.y);
        
    }
    protected void UpdatePositionPaddleY(){
        this.transform.position = this.transform.position.y < -7f ? new Vector2(this.transform.position.x,-7) : 
                            this.transform.position.y > 7 ? new Vector2(this.transform.position.x,7) : new Vector2(this.transform.position.x,this.transform.position.y);
    }
}
