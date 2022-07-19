using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The monsters spawn every certain amount of seconds in a radius. Our current concept is that every night, the spawner will spawn more and more enemies 
/// </summary>
public class BaseMonsterSpawner : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int secondsPerEnemy = 1;
    [SerializeField] private bool isSpawning = false;
    [SerializeField] private int maxPerRound = 5; 

   
    private float time; 

    private int currentAmt = 0;

    private void Start()
    {
        time = 0;
        isSpawning = false;
    }

    private void Update()
    {
        if (!isSpawning || currentAmt > maxPerRound ) return; 

        time += Time.deltaTime;

        if (time > secondsPerEnemy)
        {
            var location = new Vector3(transform.position.x, transform.position.y, 0);

            var go = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], location + (Vector3)Random.insideUnitCircle.normalized * radius, Quaternion.identity);
            go.transform.parent = transform;
            time = 0;
            currentAmt++;
        }
       



    }
    private void ResetRound()
    {
        currentAmt = 0;
        isSpawning = true;
        maxPerRound++;
        //extra logic here. 
    }

    private void NoSpawn()
    {
        isSpawning=false;
    }
    private void OnEnable()
    {
       
        DayNightScript.beginNight += ResetRound;
        DayNightScript.beginDay += NoSpawn;
    }

    private void OnDisable()
    {
        //accomadate for "death". death = disbale 
      
        DayNightScript.beginNight -= ResetRound;
        DayNightScript.beginDay -= NoSpawn;
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Color col = new Color(1.5f, 0.6f, 0.5f, 0.33f);
        Gizmos.color = col;
       
        Gizmos.DrawSphere(transform.position, radius);
    }
}
