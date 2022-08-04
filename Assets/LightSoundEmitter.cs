using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSoundEmitter : MonoBehaviour
{

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public void PlayLightSound()
    {
        Debug.Log("playin some sounds");
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Light Turning/LightTurning", transform.position);
    }
}
