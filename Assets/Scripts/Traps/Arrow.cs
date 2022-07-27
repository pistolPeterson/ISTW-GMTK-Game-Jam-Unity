using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //can only kill when it is fired
    [SerializeField] private int piercePower = 3; 
    private int currentPow;

    private void Start()
    {
        currentPow = piercePower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       

        if (collision.CompareTag("Enemy"))
        {
            if(currentPow > 0)
            {
                FindObjectOfType<Inventory>().KillConfirmed();
                // Destroy(collision.gameObject, 0.15f);
                var baseEnemy = collision.gameObject.GetComponent<BaseEnemy>();
                if (baseEnemy != null)
                {
                    Debug.Log("this enemy dead af");
                    baseEnemy.Die();

                }
                currentPow--;
            }
            
        }
    }


    public void ResetPierce()
    {
        currentPow = piercePower;
    }
}
