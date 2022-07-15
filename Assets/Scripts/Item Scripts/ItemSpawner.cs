using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] private float radius;
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private int secondsPerSpawn = 1;

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
            var go = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)], Random.insideUnitCircle * radius, Quaternion.identity);
            go.transform.parent = transform;
            time = 0;

        }
    }


    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Color col = new Color(1.5f, 1.6f, 0.5f, 0.33f);
        Gizmos.color = col;

        Gizmos.DrawSphere(transform.position, radius);
    }
}
