using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip dayMusic;
    public AudioClip nightMusic;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusicFadeIn(dayMusic, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DayMusic()
    {
        //start coroutine that 
        //stops current music 
        //wait one sec 
        //start day music 
        Debug.Log("starting day musci");
        StartCoroutine(dayMusicIenum());
    }
    public void NightMusic()
    {
        //start coroutine that 
        //stops current music 
        //wait one sec 
        //start day music 
        Debug.Log("starting day musci");
        StartCoroutine(nightMusicIenum());
    }

    public IEnumerator dayMusicIenum()
    {
        AudioManager.Instance.StopMusicFadeOut();

        yield return new WaitForSeconds(1);
        AudioManager.Instance.PlayMusicFadeIn(dayMusic, 2f);


    }

    public IEnumerator nightMusicIenum()
    {
        AudioManager.Instance.StopMusicFadeOut();

        yield return new WaitForSeconds(1);
        AudioManager.Instance.PlayMusicFadeIn(nightMusic, 2f);


    }

    private void OnEnable()
    {
        DayNightScript.beginDay += DayMusic;
        DayNightScript.beginNight += NightMusic;
    }

    private void OnDisable()
    {
        DayNightScript.beginDay -= DayMusic;
        DayNightScript.beginNight -= NightMusic;
    }
}
