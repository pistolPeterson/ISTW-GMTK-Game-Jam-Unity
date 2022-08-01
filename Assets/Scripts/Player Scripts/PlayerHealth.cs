using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class PlayerHealth : Health
{
    public bool isAlive = true;
    public static event Action OnDeath;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Add the splatter image here")]
    [SerializeField] private Image redSplatterImage = null;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
    }

    private void UpdateHealth()
    {
        Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 1 - ((float)health / maxHealth);
        redSplatterImage.color = splatterAlpha; 
    }
    public override void TakeDamage(int dmg)
    {
        if (!isAlive) return;
        health -= dmg;

        UpdateHealth();

        if (health <= 0)
        {
            Die();        
        }
        else
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/Player Hurt/Player Hurt", transform.position);


    }

    public override void Die()
    {
        //show death animation, stop player from moving, show stats with button to restart
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Player/Player Die", transform.position);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI + Stingers/Player Die Stinger", transform.position);
        health = 0;
        OnDeath?.Invoke();
        isAlive = false;
        FindObjectOfType<PlayerMovement>().FreezePlayer();
    }

    
    
}
