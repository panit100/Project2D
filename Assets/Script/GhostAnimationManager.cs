using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimationManager : MonoBehaviour
{
    public float playTime = 0;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(StartAniamtion());
    }

    IEnumerator StartAniamtion(){
        yield return new WaitForSeconds(playTime);
        GetComponent<Animator>().SetBool("Play",true);

    }
}
