using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosterSpawnDice : MonoBehaviour
{
    [SerializeField] private float waitTime;

    [SerializeField] private GameObject speedEnemyPrefab;
    [SerializeField] private GameObject tankEnemyPrefab;

    [SerializeField] private float radius;

    [SerializeField] private List<Sprite> dieSides;
    [SerializeField] private Image dieImageHolder;
    private int currentDieSide;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            int num = Random.Range(1, 7);
            StartCoroutine(specialSpawn(num));
        }




    }

    //when night event is popped off 
    //for 3 secs randomly go through all six sides of die 
    //on the last one it stops on, thats when you call special spawn
    //
    public void StartDieSystem()
    {
        StartCoroutine(DieSystem());
    }
    public IEnumerator DieSystem()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI + Stingers/Dice Roll", transform.position);
        for (int i = 0; i < 50; i++)
        {
            var num = Random.Range(0, 5);
            currentDieSide = num;
            dieImageHolder.sprite = dieSides[num];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(specialSpawn(currentDieSide + 1));

    }
    private void OnEnable()
    {
        DayNightScript.beginNight += StartDieSystem;  
    }

    private void OnDisable()
    {
        DayNightScript.beginNight -= StartDieSystem;
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
