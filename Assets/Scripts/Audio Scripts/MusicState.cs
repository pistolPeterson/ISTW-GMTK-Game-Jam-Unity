using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MusicState : MonoBehaviour
{

    public MusicMotor motor;
    
    public AudioClip clip;
    private void Start()
    {
        motor = FindObjectOfType<MusicMotor>();     
    }

    public virtual void StateChangeCheck()
    {

    }




    public virtual void StartPlaying()
    {
        AudioManager.Instance.PlayMusicFadeIn(clip, 0.5f);
    }


    public virtual void StopPlaying()
    {
        AudioManager.Instance.StopMusicFadeOut();
    }
}
