using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour
{
    public int tankHealth = 2;
    // Start is called before the first frame update
    void Start()
    {
        tankHealth = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        Debug.Log("tank kinda damaged ");
        tankHealth--;
        CheckDie();
    }

    public void CheckDie()
    {
        if (tankHealth <= 0)
        {
            Debug.Log("tank dead af");
            Destroy(gameObject);
        }
    }
}
