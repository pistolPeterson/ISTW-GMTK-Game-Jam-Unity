using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrokenBearTrapItem : ICollectible
{
    public static event Action OnBrokenBearTrapCollected;

    public override void Collect()
    {
        OnBrokenBearTrapCollected?.Invoke();

        //turn invisible 
        TurnInvisble();


        //delete itself when branch sound is done
        Destroy(gameObject, 0.1f);
    }

}
