using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMusicState : MusicState 
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

        //if it turns day, go to day music state



    }
    public override void StartPlaying()
    {
        //AudioManager.Instance.PlayMusicFadeIn(clip, 1f);
        //Another music manager with 3 audio clips in it.
            //start all of them, mute the second 2 track
            //start another state machine 


        //if there is more than 3 enemies near player
            //unmute layer 

        //if there is zero near player 
            //mute layer


        //if player health drops below 33
            //umute layer 


    }


    public override void StopPlaying()
    {
        AudioManager.Instance.StopMusicFadeOut();
        //stop all the music from the state machine 
    }
}
