using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Jumping : MonoBehaviour, IPointerDownHandler
{
    PlayerController playerController;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        playerController.Jumping();
    }
    
}
