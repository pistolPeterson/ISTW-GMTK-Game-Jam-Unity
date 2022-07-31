using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Inventory : MonoBehaviour
{
    [Header("these fields are for debugging, do not touch!")]
    [SerializeField] private int ropes;
    [SerializeField] private int thornyBranches;
    [SerializeField] private int vines;
    [SerializeField] private int brokenBearTraps;

    private int enemiesKilled = 0;

    [Header("the trap prefabs")]
    public GameObject branchSpikeTrapPrefab;
    public GameObject harpoonTrapPrefab;
    public GameObject fixBearTrapPrefab;

    [Header("this is how much it 'costs' to make each type of weapon")]
    public int itemWeight;

    [Header("The UI Text trap objects")]
    public GameObject bearTrap;
    public GameObject bowArrow;


    [Header("Trap Recipes")]
    public TrapRecipe bearTrapRec;
    public TrapRecipe branchTrapRec;
    public TrapRecipe bowArrowTrapRec;

    public static event Action OnInventoryUIUpdate;

    private PlayerPlaceItem placeItem;

    public int Ropes { get => ropes; set => ropes = value; }
    public int ThornyBranches { get => thornyBranches; set => thornyBranches = value; }
    public int Vines { get => vines; set => vines = value; }
    public int BrokenBearTraps { get => brokenBearTraps; set => brokenBearTraps = value; }

    //4 prefabs of the trap items 


    private void Start()
    {
        placeItem = GetComponent<PlayerPlaceItem>();
        enemiesKilled = 0;
        ropes = 5;
        thornyBranches = 5;
        brokenBearTraps = 5;
        vines = 5;

        bearTrap.SetActive(false);
        bowArrow.SetActive(false);

    }

    private void Update()
    {
        if (CanMakeTrap(bearTrapRec))
            bearTrap.SetActive(true);
        else
            bearTrap.SetActive(false);

        if (CanMakeTrap(bowArrowTrapRec))
            bowArrow.SetActive(true);
        else
            bowArrow.SetActive(false);

        //if (Input.GetKeyDown(KeyCode.J) && CanMakeTrap(bearTrapRec))
        //{
        //    Debug.Log("gimme a fixed bear trap now");
        //    //spawn branch spike trap here
        //    Instantiate(fixBearTrapPrefab, this.gameObject.transform.position, Quaternion.identity);
        //    thornyBranches -= itemWeight;
        //    brokenBearTraps -= itemWeight;
        //}

        //if (Input.GetKeyDown(KeyCode.K) && CanMakeTrap(bowArrowTrapRec))
        //{
        //    Debug.Log("gimme a harpoon trap now");
        //    //spawn branch spike trap here
        //    Instantiate(harpoonTrapPrefab, this.gameObject.transform.position, Quaternion.identity);
        //    ropes -= itemWeight;
        //    vines -= itemWeight;
        //}

    }

    private void OnEnable()
    {
        BranchItem.OnBranchCollected += BranchPickedUp;
        VineItem.OnVineCollected += VinePickedUp;
        BrokenBearTrapItem.OnBrokenBearTrapCollected += BrokenBearTrapPickedUp;
        RopeItem.OnRopeCollected += RopeItemPickedup;

        CraftingPanelUI.OnCraftButtonClicked += CreateItem;
    }
    private void OnDisable()
    {
        BranchItem.OnBranchCollected -= BranchPickedUp;
        VineItem.OnVineCollected -= VinePickedUp;
        BrokenBearTrapItem.OnBrokenBearTrapCollected -= BrokenBearTrapPickedUp;
        RopeItem.OnRopeCollected -= RopeItemPickedup;

        CraftingPanelUI.OnCraftButtonClicked -= CreateItem;


    }
    public void RopeItemPickedup() { ropes++; OnInventoryUIUpdate?.Invoke(); }
    public void BranchPickedUp() { thornyBranches++; OnInventoryUIUpdate?.Invoke(); }
    public void VinePickedUp() { vines++; OnInventoryUIUpdate?.Invoke(); }
    public void BrokenBearTrapPickedUp() { brokenBearTraps++; OnInventoryUIUpdate?.Invoke(); }

    public bool CanMakeTrap(TrapRecipe recipe)
    {
        if (thornyBranches < recipe.branchAmount)
            return false;

        if (ropes < recipe.ropeAmount)
            return false;

        if (vines < recipe.vineAmount)
            return false;

        if (brokenBearTraps < recipe.bbearTrapAmount)
            return false; 

        return true; 
    }

    public void InvokeUIUpdate() { OnInventoryUIUpdate?.Invoke(); }
    public void Add(ItemType itemType, int amt)
    {
        switch (itemType)
        {
            case ItemType.VINE:
                vines += amt;
                break;
            case ItemType.BROKEN_BEAR_TRAP:
                brokenBearTraps += amt;
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

    public void CreateItem()
    {
        int selectedItem = FindObjectOfType<CraftingPanelUI>().CurrentlySelectedItem();
        //this can be turned into a method/ switch statement
        if (selectedItem == 0 && CanMakeTrap(bearTrapRec))
        {
            //instead of instantiate here, you delagate to a new script that handles placement 
            //parameters, just the trap type! 
           // Instantiate(fixBearTrapPrefab, this.gameObject.transform.position, Quaternion.identity);

            //psuedocode 
            //set active a fake trap in front of player
            //if player presses enter then it will actually be placed 
            //save position and rotation of temp trap,set temp trap to inacitve 
            //instantiate based on the saved data at the place 

            placeItem.PlaceItemMode(bearTrapRec);

            RemoveItemsFromInventory(bearTrapRec);
        }

        if (selectedItem == 1 && CanMakeTrap(bowArrowTrapRec))
        {
           // Instantiate(harpoonTrapPrefab, this.gameObject.transform.position, Quaternion.identity);
            placeItem.PlaceItemMode(bowArrowTrapRec);

            RemoveItemsFromInventory(bowArrowTrapRec);
        }


        if (selectedItem == 2 && CanMakeTrap(branchTrapRec))
        {
           // Instantiate(branchSpikeTrapPrefab, this.gameObject.transform.position, Quaternion.identity);
            placeItem.PlaceItemMode(branchTrapRec);

            RemoveItemsFromInventory(branchTrapRec);

        }
    }
    
    public void RemoveItemsFromInventory(TrapRecipe recipe)
    {
        ropes -= recipe.ropeAmount;
        vines -= recipe.vineAmount;
        thornyBranches -= recipe.branchAmount;
        brokenBearTraps -= recipe.bbearTrapAmount;
    }

    //brute force approach? can this be cleaner?
    public int CurrentMaxAmountCanMake(TrapRecipe recipe)
    {
        //if you dont even have enough items for a single trap, return 0
        if(!CanMakeTrap(recipe)) return 0;
        bool canCraft = true;
        // at this point we are garanteed one or more traps we can make; 
        int amt = 0;
       
        int tRopes = ropes; 
        int tVines = vines;
        int tbbTrap = brokenBearTraps;
        int tBranches = thornyBranches;
        while (canCraft)
        {
            if(recipe.ropeAmount > tRopes || recipe.vineAmount > tVines || recipe.bbearTrapAmount > tbbTrap || recipe.branchAmount > tBranches)
            {
                canCraft = false;
            }
            else
            {
                tRopes -= recipe.ropeAmount;
                tVines -= recipe.vineAmount;
                tBranches -= recipe.branchAmount;
                tbbTrap -= recipe.bbearTrapAmount;

                amt++;
            }
           
        }
    

        //should return the smallest amount we can make
        return amt;
    }
    public int PotentialBearTraps() { return CurrentMaxAmountCanMake(bearTrapRec); }
    public int PotentialBowArrowTraps() { return CurrentMaxAmountCanMake(bowArrowTrapRec); }
    public int PotentialBranchTraps() { return CurrentMaxAmountCanMake(branchTrapRec); }

    public void KillConfirmed() { enemiesKilled++; }
    public int GetEnemiesKilled() { return enemiesKilled; }
}

