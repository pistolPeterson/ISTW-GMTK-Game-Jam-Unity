using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchTrap : Trap
{
    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Branch/BranchUse", transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TrapAbility(Collider2D collision)
    {
       // base.TrapAbility(collision);
        //if tank, take more than half health off
        //tank makes a sound
        var attemptTank = collision.gameObject.GetComponent<TankEnemy>(); 
        if(attemptTank != null)
        {
           if(Random.Range(0, 500) % 2 == 0) //branches have 50% chance to actually kill enemies
                attemptTank.Damage();

            Destroy(this.gameObject);
            return; //safety break so it doesnt go through the rest of the method before it gets destroyed  
        }


        //if not tank, kill them
        //(call their kill method? they say a screech then destroy themselves)
        var attemptedBaseEnemy = collision.gameObject.gameObject.GetComponent<BaseEnemy>();
        if(attemptedBaseEnemy != null)
        {
            // call its kill method, it dies then makes a death sfx 

            if (Random.Range(0, 500) % 2 == 0)
                attemptedBaseEnemy.Die();

            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Branch/BranchUse", transform.position);
            Destroy(this.gameObject);
        }

       
           

        




    }
}
