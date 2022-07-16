using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{




    public float stepRate = 0.33f;
    public float stepCoolDown;
    public List<AudioClip> footSteps;
    public AudioSource audioSource;
    private PlayerMovement pm;
    private void Start()
    {
        pm = GetComponent<PlayerMovement>();    
    }



    // Update is called once per frame
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            if (pm.IsFreeze == true) return;
            audioSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
            audioSource.PlayOneShot(ChooseRandomFootstep(footSteps), 0.05f);
            stepCoolDown = stepRate;
        }
    }



    public AudioClip ChooseRandomFootstep(List<AudioClip> footsteps)
    {
        int num = Random.Range(0, footsteps.Count);


        return footsteps[num];
    }
}
