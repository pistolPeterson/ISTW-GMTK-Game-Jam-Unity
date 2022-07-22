using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchSpawner : ItemSpawner
{

    public override void SpawnItem()
    {
        //get all the mini child spawners 
        var childs = GetComponentsInChildren<ChildSpawner>();
        if (childs == null) return; 

        //pick one
        int num = Random.Range(0, childs.Length);

        //make it spawn the item in that child spawner radius
        var go = Instantiate(itemPrefab, (Vector2)childs[num].gameObject.transform.position + Random.insideUnitCircle * radius, Quaternion.identity);
        go.transform.parent = transform;

    }
}
