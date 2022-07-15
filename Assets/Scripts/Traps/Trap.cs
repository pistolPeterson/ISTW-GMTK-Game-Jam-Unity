using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private AudioClip trapKill; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //trap sfx 
            //stop enemy moving 
            //send something to ui to alert player 
            Destroy(collision.gameObject, 0.33f);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
