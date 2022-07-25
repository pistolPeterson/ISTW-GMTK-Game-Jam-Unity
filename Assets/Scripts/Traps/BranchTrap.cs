using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchTrap : Trap
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TrapAbility(Collider2D collision)
    {
        Debug.Log("any collision detected tho");
       // base.TrapAbility(collision);
        //if tank, take more than half health off
        //tank makes a sound
        var attemptTank = collision.gameObject.GetComponent<TankEnemy>(); 
        if(attemptTank != null)
        {
            //attemptTank.damage(most of thier health) inside it is their dmg sfx 
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
            Destroy(this.gameObject);

            attemptedBaseEnemy.Die();
        }

        




    }
}
