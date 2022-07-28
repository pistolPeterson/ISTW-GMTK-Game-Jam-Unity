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
    public GameObject branchSpikeTrap;
    public GameObject harpoonTrap;
    public GameObject fixBearTrap;

    [Header("this is how much it 'costs' to make each type of weapon")]
    public int itemWeight;

    [Header("The UI Text trap objects")]
    public GameObject bearTrap;
    public GameObject bowArrow;


    [Header("Trap Recipes")]
    [SerializeField] private TrapRecipe bearTrapRec;
    [SerializeField] private TrapRecipe branchTrapRec;
    [SerializeField] private TrapRecipe bowArrowTrapRec;

    public static event Action OnInventoryUIUpdate;

    public int Ropes { get => ropes; set => ropes = value; }
    public int ThornyBranches { get => thornyBranches; set => thornyBranches = value; }
    public int Vines { get => vines; set => vines = value; }
    public int BrokenBearTraps { get => brokenBearTraps; set => brokenBearTraps = value; }

    //4 prefabs of the trap items 


    private void Start()
    {
        enemiesKilled = 0;
        ropes = 0;
        thornyBranches = 0;
        brokenBearTraps = 0;
        vines = 0;

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

        if (Input.GetKeyDown(KeyCode.J) && CanMakeTrap(bearTrapRec))
        {
            Debug.Log("gimme a fixed bear trap now");
            //spawn branch spike trap here
            Instantiate(fixBearTrap, this.gameObject.transform.position, Quaternion.identity);
            thornyBranches -= itemWeight;
            brokenBearTraps -= itemWeight;
        }

        if (Input.GetKeyDown(KeyCode.K) && CanMakeTrap(bowArrowTrapRec))
        {
            Debug.Log("gimme a harpoon trap now");
            //spawn branch spike trap here
            Instantiate(harpoonTrap, this.gameObject.transform.position, Quaternion.identity);
            ropes -= itemWeight;
            vines -= itemWeight;
        }

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
            //special code to hold it on him before he places it 
            Instantiate(fixBearTrap, this.gameObject.transform.position, Quaternion.identity);

            //code to remove out of inventory items based on recipe
            RemoveItemsFromInventory(bearTrapRec);
        }

        if (selectedItem == 1 && CanMakeTrap(bowArrowTrapRec))
        {
            Instantiate(harpoonTrap, this.gameObject.transform.position, Quaternion.identity);
            RemoveItemsFromInventory(bowArrowTrapRec);
        }


        if (selectedItem == 2 && CanMakeTrap(branchTrapRec))
        {
            Instantiate(branchSpikeTrap, this.gameObject.transform.position, Quaternion.identity);
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

        // at this point we are garanteed one or more traps we can make; 
        int amt = int.MaxValue;
        int w = int.MaxValue, x = int.MaxValue, y = int.MaxValue, z = int.MaxValue;
        //cache in all the items we currently have in the inventory
        int tempRopes = ropes; 
        int tempVines = vines;
        int tempbbTraps = brokenBearTraps;
        int tempBranches = thornyBranches;

        //how many traps can we make with just the ropes? 
        if(recipe.ropeAmount != 0)
         w = tempRopes / recipe.ropeAmount;
        if(w < amt)//make it the new amt if its less than the current amt
            amt = w;

        //how many traps can we make with just the vines? 
        if (recipe.vineAmount != 0)
            x = tempVines / recipe.vineAmount;
        if (x < amt)
            amt = x;

        //etc..
        if (recipe.bbearTrapAmount != 0)
            y = tempbbTraps / recipe.bbearTrapAmount;
        if (y < amt)
            amt = y;

        //etc..
        if (recipe.branchAmount != 0)
            z = tempBranches / recipe.branchAmount;
        if (y < amt)
            amt = z;

        //should return the smallest amount we can make
        return amt;
    }
    public int PotentialBearTraps() { return CurrentMaxAmountCanMake(bearTrapRec); }
    public int PotentialBowArrowTraps() { return CurrentMaxAmountCanMake(bowArrowTrapRec); }
    public int PotentialBranchTraps() { return CurrentMaxAmountCanMake(branchTrapRec); }

    public void KillConfirmed() { enemiesKilled++; }
    public int GetEnemiesKilled() { return enemiesKilled; }
}

