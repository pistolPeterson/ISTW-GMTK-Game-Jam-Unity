using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class VineItem : ICollectible
{
    public static event Action OnVineCollected;

    public override void Collect()
    {
        OnVineCollected?.Invoke();
        Debug.Log("You collected a vine");

        //turn invisible 
        TurnInvisble();


        //delete itself when branch sound is done
        Destroy(gameObject, 0.1f);
    }

  

}
