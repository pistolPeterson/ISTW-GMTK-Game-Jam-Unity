using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayMusicState : MusicState
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
        //if player dies, go to death ambient state 

        //if it turns night, go to day music state
    }
    public override void StartPlaying()
    {
        AudioManager.Instance.PlayMusicFadeIn(clip, 1f);
    }


    public override void StopPlaying()
    {
        AudioManager.Instance.StopMusicFadeOut();
    }
}
