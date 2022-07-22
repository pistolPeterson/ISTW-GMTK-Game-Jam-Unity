using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("yo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("peterson");
        ICollectible collectible = collision.GetComponent<ICollectible>();  
        if (collectible != null)
        {
            collectible.Collect();
        }
    }
}
