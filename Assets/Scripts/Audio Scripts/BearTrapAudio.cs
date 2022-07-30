using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Bear Trap/Bear Trap Place", transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
