using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterSpawnDice : MonoBehaviour
{
    [SerializeField] private float waitTime;

    [SerializeField] private GameObject speedEnemyPrefab;
    [SerializeField] private GameObject tankEnemyPrefab;

    [SerializeField] private float radius;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
           
            int num = Random.Range(1, 7);
            StartCoroutine(specialSpawn(num));
        }
    }

    public IEnumerator specialSpawn(int amtToSpawn)
    {
        //wait the appointed time 
        yield return new WaitForSeconds(waitTime);
       
        var location = new Vector3(transform.position.x, transform.position.y, 0);
        var specificLocation = location + (Vector3)Random.insideUnitCircle.normalized * radius;
        var specificLocation2 = location + (Vector3)Random.insideUnitCircle.normalized * radius;



        for (int i = 0; i < amtToSpawn; i++)
        {
            yield return new WaitForSeconds(waitTime/amtToSpawn);
            var go = Instantiate(speedEnemyPrefab, specificLocation, Quaternion.identity);
            var go2 = Instantiate(tankEnemyPrefab, specificLocation2, Quaternion.identity);
            go.transform.parent = transform;
            go2.transform.parent = transform;

        }


    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Color col = new Color(1.5f, 0.6f, 0.5f, 0.33f);
        Gizmos.color = col;

        Gizmos.DrawSphere(transform.position, radius);
    }
}
