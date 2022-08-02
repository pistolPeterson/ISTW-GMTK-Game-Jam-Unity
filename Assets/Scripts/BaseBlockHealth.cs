using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlockHealth : Health
{

    private void Start()
    {
        maxHealth = 250;
        health = maxHealth;
            
     }

    public override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        if (health < maxHealth / 10)
        {
            //play broken wood sound to tell player its about to die 
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
