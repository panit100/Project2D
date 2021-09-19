using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class AnalyticManager : MonoBehaviour
{
    Scene scene;
    private void Awake() {
        scene = SceneManager.GetActiveScene();
    }
    public void LogData(int score,float time){
        Dictionary<string,object> customParams = new Dictionary<string, object>();
        customParams.Add("Score",score);
        customParams.Add("Time",time);

        AnalyticsEvent.LevelFail(scene.name,scene.buildIndex,customParams);
    }

    public void LogCustom(int score,float time){
        AnalyticsResult analytics = Analytics.CustomEvent("CustomData1 : " + score);
        Debug.Log("AnalyticsResult : " + analytics);


        AnalyticsResult analyticsDic = Analytics.CustomEvent("CustomDataDic : " , 
            new Dictionary<string,object>{
                {"Score",score},{"Time",time}
            }
        );
        Debug.Log("AnalyticsResultDic : " + analyticsDic);
    }
}
