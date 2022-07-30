using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceItem : MonoBehaviour
{
   


    [SerializeField] private GameObject placementLoc;

    private bool inPlacementMode = false;

    private Inventory inv;
    private GameObject currentObjToPlace;

    // Start is called before the first frame update
    void Start()
    {
        inPlacementMode = false; 
        inv = GetComponent<Inventory>();
        SetAllObjectsInactive();
    }

    // Update is called once per frame
    void Update()
    {
        if(inPlacementMode)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Vector3 realPos = transform.TransformPoint(0,0,0);
                Quaternion rot = transform.rotation;
                placementLoc.gameObject.SetActive(false);
                if(currentObjToPlace == null)
                {
                    Debug.Log("Current object ot place is null");
                    return; 
                }

                var go = Instantiate(currentObjToPlace, realPos, rot);
               
                inPlacementMode = false;
            }
        }

        //if bool mode 
        // if you press enter 
        //grab info from placement loc and hold it 
        //set placement loc to inactive 
        //instantiate here with placement loc info 
        //set bool mode back to false 
    }

    public void PlaceItemMode(TrapRecipe trapRecipe)
    {
        placementLoc.SetActive(true);
        SpriteRenderer sr = placementLoc.gameObject.GetComponent<SpriteRenderer>();

        sr.sprite = trapRecipe.weaponSprite;
        currentObjToPlace = trapRecipe.weaponPrefab;
        inPlacementMode = true;

    }
    private void SetAllObjectsInactive()
    {
      

        placementLoc.gameObject.SetActive(false);
    }
}

