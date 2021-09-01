using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonManager : MonoBehaviour
{
    //Json File;
    string json;

    //Class ColorData
    public class ColorData{
        public Color playerColor;
        public List<int> unlockColor = new List<int>();
    }
    public ColorData colorData;
    public ScriptManager ScriptManager;
    public string path;
	
    private void Start() {
    
        // #if UNITY_EDITOR
        //     Debug.Log("Unity Editor");
        //     path = Application.dataPath + "/StreamingAssets";
        // #elif UNITY_ANDROID
        //    Debug.Log("Andriod");
        //    path = "jar:file://" + Application.persistentDataPath + "/StreamingAssets";
        // #endif

        // #elif UNITY_STANDALONE
        //     Debug.Log("Standalone Windows");
        //     path = Application.dataPath + "/StreamingAssets";
        // #endif
    }

    //Json
    //Save
    public void CreateJson(){
        
        ColorData NewcolorData = new ColorData();

        NewcolorData.playerColor = ScriptManager.selectColor;
        NewcolorData.unlockColor = ScriptManager.unlocked;

		json = JsonUtility.ToJson(NewcolorData);
		File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/Color.json",json);

        #if UNITY_EDITOR
            Debug.Log("Unity Editor");
            File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/Color.json",json);
        #elif UNITY_ANDROID
           Debug.Log("Andriod");
           File.WriteAllText("jar:file://" + Application.persistentDataPath + "/StreamingAssets" + "/Color.json",json);
        #endif
        
        
	}

	//Load
	public void LoadJson(){
		
        
        #if UNITY_EDITOR
            Debug.Log("Unity Editor");
            string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/Color.json");
        #elif UNITY_ANDROID
           Debug.Log("Andriod");
           string jsonFromFile = File.ReadAllText("jar:file://" + Application.persistentDataPath + "/StreamingAssets" + "/Color.json");
        #endif

		colorData = JsonUtility.FromJson<ColorData>(jsonFromFile);

	}

}