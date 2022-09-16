using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Extra functionality that they are able to "grab" on to the player and slow them down substantially before letting go
/// </summary>

public class SpeedEnemy : MonoBehaviour
{
    private bool isGrabbing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpecialAbility()
    {
        if (!isGrabbing)
        StartCoroutine(Grabby());
        
    }

    private IEnumerator Grabby()
    {
        isGrabbing = true;
        Debug.Log("doing some grabby"); 
        yield return new WaitForSeconds(0.2f);
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        //be a child of the player object 
        if (player.gameObject == null)
        {
            Debug.Log("player is null");
           
        }
        this.gameObject.transform.parent = player.transform;
        player.SetPlayerSpeed(2.0f);
        yield return new WaitForSeconds(1.0f);
        player.SetOrigSpeed();
        //for 3 sec player is more slow 
        //stop being a child of the player object 
        this.gameObject.transform.parent = null;
        isGrabbing=false;
    }

}
