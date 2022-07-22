using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The generic item spawner class. you would inherit it from another spawner class so you can customize the spawn system for it
/// </summary>
public class ItemSpawner : MonoBehaviour
{

    [SerializeField] protected GameObject itemPrefab;
    [SerializeField] [Range(0.1f, 10.0f)] protected float secondsPerSpawn = 1;
    [SerializeField] protected float radius = 2f;
    private float time;


    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > secondsPerSpawn)
        {
           SpawnItem();
           time = 0;
        }
    }


    public virtual void SpawnItem()
    {
        var go = Instantiate(itemPrefab, Random.insideUnitCircle * radius, Quaternion.identity);
        go.transform.parent = transform;
    }


   
}
