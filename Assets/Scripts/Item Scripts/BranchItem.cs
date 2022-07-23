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
        Debug.Log("You collected a branch");

        //turn invisible 
        TurnInvisble();

        //play branch collected sound, use the event thingy

        //delete itself when branch sound is done

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("branch gang");
    }

   
}
