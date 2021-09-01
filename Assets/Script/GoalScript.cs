using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public TextMeshProUGUI MiddleText;
    public TextMeshProUGUI ObjectiveText;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            if(other.GetComponent<PlayerController>().getkey is true){
                //Endgame
                ShowMiddleText("Adios");
                StartCoroutine(LoadMainMenu());
            }else{
                //show text
                ShowMiddleText("Find Key");
            }
        }        
    }

    private void Start() {
        ShowMiddleText("Find Hidden Temple");
    }

    //hide mid text
    IEnumerator HideMiddleText(string text){
        yield return new WaitForSeconds(2);
        MiddleText.gameObject.SetActive(false);
        ObjectiveText.text = text;

    }

    public void ShowMiddleText(string text){
        MiddleText.gameObject.SetActive(true);
        MiddleText.text = text;
        StartCoroutine(HideMiddleText(text));
    }

    IEnumerator LoadMainMenu(){
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
