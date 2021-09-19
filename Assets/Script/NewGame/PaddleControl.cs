using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : Paddle
{
    public bool paddleUpDown = false;
    private void Update() {
        if(paddleUpDown){
            UpdatePositionPaddleX();
        }else{
            UpdatePositionPaddleY();
        }
    }

    private void FixedUpdate() {
        if(paddleUpDown){
            ControllerUpDown();
        }else{
            ControllerLeftRight();
        }
    }
}
