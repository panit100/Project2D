using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectedColor : MonoBehaviour, IPointerClickHandler
{
    ScriptManager scriptManager;
    Image image;

    private void Start() {
        scriptManager = FindObjectOfType<ScriptManager>();
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        if(image.color == Color.black){
            return;
        }
        scriptManager.SelectColor(image.color);

        
    }
}
