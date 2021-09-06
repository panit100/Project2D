using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;
using UnityEditor.Audio;
public class CamIntro : MonoBehaviour
{
    [System.Serializable]
    public class VcamSetting{
        public bool DarkVolume = false;
        public CinemachineVirtualCamera vcam;
    }
    
    CinemachineBrain cinemachineBrain;
    
    public List<VcamSetting> VcamSet = new List<VcamSetting>();
    public int currentPos = 0;
    public Volume volume;
    public Animator Redeye1;
    public Animator Redeye2;
    
    public AudioSource monster;
    public AudioSource Noise;
    public AudioSource Bell;
    

    void Start()
    {
        cinemachineBrain = GetComponent<CinemachineBrain>();
    }

    private void Update() {
        UpdatePosition();
    }

    void UpdatePosition(){
        if(cinemachineBrain.ActiveBlend == null){
            currentPos++;
            if(currentPos < VcamSet.Count){
                VcamSet[currentPos].vcam.enabled = true;
                
                if(VcamSet[currentPos].DarkVolume){
                    volume.enabled = true;
                    if(!Noise.isPlaying){
                        Noise.Play();
                    }

                    if(currentPos%2 !=0){
                        Bell.Play();
                    }
                }else{
                    volume.enabled = false;
                    Noise.Stop();
                }
            }

            
        }

        if(currentPos > VcamSet.Count){
                Redeye1.SetBool("Play",true);
                Redeye2.SetBool("Play",true);
                if(!monster.isPlaying){
                    monster.Play();
                }
            }
    }
}
