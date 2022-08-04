using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BranchItem :  ICollectible
{

    public static event Action OnBranchCollected;

    public override void Collect()
    {
        OnBranchCollected?.Invoke();

        //turn invisible 
        TurnInvisble();


        //delete itself when branch sound is done
        Destroy(gameObject, 0.1f);
    }

   

   
}
