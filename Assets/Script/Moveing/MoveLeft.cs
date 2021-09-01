using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PlayerController playerController;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        playerController.goLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUP");
        playerController.goLeft = false;
    }

    
}
