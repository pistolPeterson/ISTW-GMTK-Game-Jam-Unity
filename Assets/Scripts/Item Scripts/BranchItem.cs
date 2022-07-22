using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BranchItem : MonoBehaviour, ICollectible
{

    public static event Action OnBranchCollected;

    public void Collect()
    {
        OnBranchCollected?.Invoke();
        Debug.Log("You collected a branch");

        //turn invisible 
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Debug.Log("yo????");
            var col = sr.color;
            col.a = 0f;
            sr.color = col;
          

        }

        //play branch collected sound, use the event thingy

        //delete itself when branch sound is done

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("branch gang");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
