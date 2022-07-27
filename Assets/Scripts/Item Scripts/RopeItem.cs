using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RopeItem : ICollectible
{
    public static event Action OnRopeCollected;

    public override void Collect()
    {
        OnRopeCollected?.Invoke();

        //turn invisible 
        TurnInvisble();


        //delete itself when branch sound is done
        Destroy(gameObject, 0.1f);
    }

}
