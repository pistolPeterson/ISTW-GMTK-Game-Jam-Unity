using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    public bool isAlive = true;
    public static event Action OnDeath;
    [SerializeField] private TextMeshProUGUI healthText;

    [Header("Add the splatter image here")]
    [SerializeField] private Image redSplatterImage = null;


    // Start is called before the first frame update
    void Start()
    {
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
        splatterAlpha.a = 1 - ((float)health / 100);
        redSplatterImage.color = splatterAlpha; 


    }
    public virtual void TakeDamage(int dmg)
    {
        if (!isAlive) return;

        health -= dmg;
        UpdateHealth();
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
