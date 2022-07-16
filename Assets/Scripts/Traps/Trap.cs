using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private AudioClip trapKill;
    [SerializeField] private AudioClip trapPlace;
    [SerializeField] private float timeUntilTrapDestroy; 
    [SerializeField]private AudioSource trapSource;

    private void Start()
    {
        RandomizeSound();
        trapSource = GetComponent<AudioSource>();
        trapSource.PlayOneShot(trapPlace);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //trap sfx 
            //stop enemy moving 
            //send something to ui to alert player 
            Destroy(collision.gameObject, 0.33f);
            Destroy(this.gameObject, timeUntilTrapDestroy);
        }
    }

    private void RandomizeSound()
    {
        trapSource.volume = Random.Range(0.75f, 0.9f);
        trapSource.pitch = Random.Range(0.97f, 1.03f);
    }
}
