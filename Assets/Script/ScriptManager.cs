using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScriptManager : MonoBehaviour
{
    public List<Color> lockColor = new List<Color>();
    public List<Image> unlockColor = new List<Image>();
    public List<int> unlocked = new List<int>();
    public Color selectColor;

    public GameObject MainMenu;

    JsonManager jsonManager;

    public void RandomColor(){
        if(unlocked.Count == 16){
            return;
        }

        int i = Random.Range(0,16);
        
        foreach(int n in unlocked){
            if(i == n){
                RandomColor();
                return;
            }
        }

        unlocked.Add(i);
        ShowUnlockColor();
    }

    void ShowUnlockColor(){
        foreach(int m in unlocked){
            unlockColor[m].color = lockColor[m];
        }
        SaveUnlock();
    }

    void LoadUnlock(){
        //load file json and link it to unlocked
        jsonManager.LoadJson();
        unlocked = jsonManager.colorData.unlockColor;
        selectColor = jsonManager.colorData.playerColor;
    }

    void SaveUnlock(){
        //save file json
        jsonManager.CreateJson();
    }

    private void Awake() {
        jsonManager = GetComponent<JsonManager>();
    }

    private void Start() {
        StartCoroutine(showMenu());
        selectColor = lockColor[0];

        LoadUnlock();
        //SaveUnlock();
        ShowUnlockColor();
    }

    IEnumerator showMenu(){
        yield return new WaitForSeconds(25f);
        //yield return new WaitForSeconds(1f);
        MainMenu.SetActive(true);
    }

    public void LoadScene(){
        SceneManager.LoadScene(1);
    }

    public void SelectColor(Color color){
        //select and save
        selectColor = color;
        SaveUnlock();
    }
}
