using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonTrap : MonoBehaviour
{
    private int ammo = 3;
    [SerializeField] private float speedMult; 
    public GameObject arrow;
    private bool fired = false;
    private float time;
    private Vector3 arrowOriginalPos;

    private void Start()
    {
        fired = false;
        time = 0;
        arrowOriginalPos = arrow.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if(ammo > 0)
            {
                FireArrow();
                ammo--;
            }
            
        }
    }

   


    //assumption arrow is already in harpoon 
    public void FireArrow()
    {
        fired = true;
        //take arrow, and just push it forward for x amount of seconds,
        //after x seconds passed, set active to false, and place it back in its original pos
        
    }
    private void Update()
    {
        time += Time.deltaTime;


        if(time > 3f )
        {
            time = 0;
            if(fired)
            {
                fired=false;
                arrow.transform.position = arrowOriginalPos;
                //put arrow back in original position
            }


        }

        if (ammo <= 0)
            {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(fired)
        {
             arrow.gameObject.transform.position += transform.right * speedMult;
        }
    }



}
