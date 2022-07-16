using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public bool isAlive = true;
    public static event Action OnDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void TakeDamage(int dmg)
    {
        if (!isAlive) return;

        health -= dmg;

        if (health <= 0)
        {
            health = 0;
            OnDeath?.Invoke();
            isAlive = false;
            FindObjectOfType<PlayerMovement>().FreezePlayer();
            //show death animation, stop player from moving, show stats with button to restart            
        }
    }

   

    public int GetHealth()
    {
        return health;
    }
}
