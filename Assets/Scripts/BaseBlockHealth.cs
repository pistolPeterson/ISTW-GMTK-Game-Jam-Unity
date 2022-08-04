using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlockHealth : Health
{
    private bool deathSoundTriggerPlayed; //to make sure it only plays once
    private void Start()
    {
        maxHealth = 120;
        health = maxHealth;
        deathSoundTriggerPlayed = false;    
            
     }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        if (health < maxHealth / 5)
        {
            if(!deathSoundTriggerPlayed)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Woodbreak/Woodbreak", transform.position);

                deathSoundTriggerPlayed = true;
            }
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
