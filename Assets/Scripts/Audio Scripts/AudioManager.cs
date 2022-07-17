using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Instance
    private static AudioManager instance;
    public AudioMixerGroup outputAudioMixerGroup;
   
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    #region Fields
    private AudioSource musicSource;
    private AudioSource musicSource2;

    private float musicVolume = 1;
    // Multiple musics
    private bool firstMusicSourceIsActive;
    #endregion

    private void Awake()
    {
       
        // Keep this instance alive throughout the whole game
        DontDestroyOnLoad(this.gameObject);

        // Create audio sources, and save them as references
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource2 = gameObject.AddComponent<AudioSource>();
      
        // Make sure to enable loop on music sources
        musicSource.loop = true;
        musicSource2.loop = true;


        AudioMixer mixer = Resources.Load("Master") as AudioMixer;

        string _OutputMixer = "Music";
        
        musicSource.outputAudioMixerGroup = outputAudioMixerGroup;
    }

    #region Pete Audio Methods (with only a single audiosource)
    //problem::will need a "wait" time so there is actually time to fade in and out in one audio source 

    public bool isPlaying()
    {
        return musicSource.isPlaying;
    }
    public void PlayMusicFadeIn(AudioClip musicClip, float fadeInTime)
    {
        musicSource.clip = musicClip;
        StartCoroutine(UpdateMusicWithFadingIn(musicSource, 1.0f));
    }

    private IEnumerator UpdateMusicWithFadingIn(AudioSource activeSource, float transitionTime)
    {
        activeSource.Play();
      

        // Fade in
        for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime) * musicVolume;
            yield return null;
        }

        // Make sure we don't end up with a weird float value
        activeSource.volume = musicVolume;
    }

    public void StopMusicFadeOut()
    {
        //fade out active audio source 
        //musicSource.clip = musicClip;
        StartCoroutine(UpdateMusicWithFadingOut(musicSource, 1f));
       
    }

    private IEnumerator UpdateMusicWithFadingOut(AudioSource activeSource, float transitionTime)
    {
       

        float t = 0.0f;

        // Fade out
        for (t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (musicVolume - ((t / transitionTime) * musicVolume));
            yield return null;
        }

        Debug.Log(activeSource.clip.name + " is the clip before stop");
        activeSource.Stop();

        // Make sure we don't end up with a weird float value
        activeSource.volume = musicVolume;
    }


    #endregion



   
}