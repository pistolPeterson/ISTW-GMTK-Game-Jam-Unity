using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager1 : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;


    private void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Day1Calm");
        Music.start();
    }
}
