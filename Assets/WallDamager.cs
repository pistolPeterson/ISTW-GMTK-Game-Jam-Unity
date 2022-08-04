using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamager : MonoBehaviour
{
    private bool damagingWall; 
    private float time;
    private BaseBlockHealth blockHealth;
    // Start is called before the first frame update
    void Start()
    {
        damagingWall = false;
        time = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 2.0f)
        {
            if(damagingWall)
            {
                if (blockHealth != null)
                {
                    blockHealth.TakeDamage(15);

                }

            }
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BaseBlockHealth>())
        {
            blockHealth = collision.gameObject.GetComponent<BaseBlockHealth>(); 
            damagingWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BaseBlockHealth>())
        {
            blockHealth = null;
            damagingWall = false;
        }
    }
}
