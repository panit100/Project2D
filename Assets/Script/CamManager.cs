using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamManager : MonoBehaviour
{
    CinemachineVirtualCamera cinemachine;
    public float time = 0;
    void Start()
    {
        cinemachine = GetComponent<CinemachineVirtualCamera>();
        StartCoroutine(ActiveCam());
    }

    IEnumerator ActiveCam(){
        yield return new WaitForSeconds(time);
        cinemachine.enabled = true;
    }
    
}
