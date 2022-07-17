using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("these fields are for debugging, do not touch!")]
    [SerializeField] private int ropes;
    [SerializeField] private int thornyBranches;
    [SerializeField] private int vines;
    [SerializeField] private int brokenBearTrap;

    [Header("the trap prefabs")]
    public GameObject branchSpikeTrap;
    public GameObject harpoonTrap;
    public GameObject fixBearTrap;

    [Header("this is how much it 'costs' to make each type of weapon")]
    public int itemWeight;

    [Header("The UI Text trap objrctss")]
    public GameObject bearTrap;
    public GameObject bowArrow;
   
    //4 prefabs of the trap items 

    private void Start()
    {
        ropes = 0;
        thornyBranches = 0;
        brokenBearTrap = 0;
        vines = 0;

        bearTrap.SetActive(false);
        bowArrow.SetActive(false);
      
    }

    private void Update()
    {

        if (HasFixedBearTrap())
            bearTrap.SetActive(true);
        else
            bearTrap.SetActive(false) ;

        if (HasHarpoonTrap())
            bowArrow.SetActive(true);
        else
            bowArrow.SetActive(false);

        if (Input.GetKeyDown(KeyCode.J) && HasFixedBearTrap())
        {
            Debug.Log("gimme a fixed bear trap now");
            //spawn branch spike trap here
            Instantiate(fixBearTrap, this.gameObject.transform.position, Quaternion.identity);
            thornyBranches -= itemWeight;
            brokenBearTrap -= itemWeight;
        }

        if (Input.GetKeyDown(KeyCode.K) && HasHarpoonTrap())
        {
            Debug.Log("gimme a harpoon trap now");
            //spawn branch spike trap here
            Instantiate(harpoonTrap, this.gameObject.transform.position, Quaternion.identity);
            ropes -= itemWeight;
            vines -= itemWeight;
        }

      

    }

    public bool HasBranchSpikeTrap() //refactor: you can use scriptable objects to make "recipes" for the traps
    {
        if (thornyBranches < itemWeight)
            return false;
        if (ropes < 0)
            return false;
        if (vines < itemWeight)
            return false;
        if (brokenBearTrap < 0)
            return false;

        return true;
    }

    public bool HasFixedBearTrap() //refactor: you can use scriptable objects to make "recipes" for the traps
    {
      
        if (ropes < itemWeight)
            return false;
        if (vines < 0)
            return false;
        if (brokenBearTrap < itemWeight)
            return false;

        return true;
    }

    public bool HasHarpoonTrap() //refactor: you can use scriptable objects to make "recipes" for the traps
    {
           
        if (ropes < itemWeight)
            return false;
        if (vines < itemWeight)
            return false;
        if (brokenBearTrap < 0)
            return false;

        return true;
    }

    public void Add(ItemType itemType, int amt)
    {
        switch (itemType)
        {
            case ItemType.VINE:
                vines+= amt;
                break;
            case ItemType.BROKEN_BEAR_TRAP:
                brokenBearTrap += amt;
                break;
            case ItemType.THORNY_BRANCH:
                thornyBranches += amt;
                break;
            case ItemType.ROPE:
                ropes += amt;
                break;
            default:
                Debug.LogWarning("Brother why is this being called");
                break;
        }

    }
}
