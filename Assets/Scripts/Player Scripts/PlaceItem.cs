using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is just for debugging. (potential cheat code system in as well)
/// </summary>
public class PlaceItem : MonoBehaviour
{

    [Header("the trap prefabs")]
    public GameObject branchSpikeTrap;
    public GameObject harpoonTrap;
    public GameObject bearTrap;
    public GameObject ropeTrap;

    public float dummyPlacementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //wrap all of these in a method? or verify in invenetory that they have enough before they place it
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(branchSpikeTrap, this.gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(harpoonTrap, this.gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(bearTrap, this.gameObject.transform.position, Quaternion.identity);

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
          //  Instantiate(ropeTrap, this.gameObject.transform.position, Quaternion.identity);
        }





    }
}
