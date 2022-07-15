using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAmbienceState : MusicState
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
        //If player presses skip button or if we reach final line of dialogue, go to day mmusic state

        //if player presses restart game, go to day music
    }
    public override void StartPlaying()
    {
        AudioManager.Instance.PlayMusicFadeIn(clip, 2f);
    }


    public override void StopPlaying()
    {
        AudioManager.Instance.StopMusicFadeOut();
    }
}
