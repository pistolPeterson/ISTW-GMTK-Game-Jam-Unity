using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField][Range(1, 500)] protected int maxHealth;
    protected int health;

    //take damage sfx 


    protected void Start()
    {
        health = maxHealth;
    }



    public virtual void TakeDamage(int dmg)
    {       
        health -= dmg;
        
        if (health <= 0)
        {
            Die();             
        }
    }

    public virtual void Heal(int amt)
    {
        health += amt;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }



    public virtual void Die()
    {
        Debug.Log("He dead, thats crazy");
    }

    public int GetHealth()
    {
        return health;
    }
}
