using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        BranchItem.OnBranchCollected += PlayBranchPickup; 
    }

    private void OnDisable()
    {
        BranchItem.OnBranchCollected -= PlayBranchPickup;

    }


    private void PlayBranchPickup()
    {
        Debug.Log("hello?");
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Branch/Branch Pick Up", GetComponent<Transform>().position);
    }
}
