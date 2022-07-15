using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicState : MusicState
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StateChangeCheck()
    {
        //If the scene we are in, is not main menu, go to DeathAmbienceState
    }




    public override void StartPlaying()
    {
        AudioManager.Instance.PlayMusicFadeIn(clip, 0.5f);
    }


    public override void StopPlaying()
    {
        AudioManager.Instance.StopMusicFadeOut();
    }

}
