using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    
    

    [SerializeField] private TextMeshProUGUI ropeText;
    [SerializeField] private TextMeshProUGUI bbTrapText;
    [SerializeField] private TextMeshProUGUI vineText;
    [SerializeField] private TextMeshProUGUI branchText;
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        ropeText.text = "0"; 
        bbTrapText.text = "0";
        vineText.text = "0";
        branchText.text = "0";


    }
    private void OnEnable()
    {
        Inventory.OnInventoryUIUpdate += UpdateInventory;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryUIUpdate -= UpdateInventory;
    }
    private void UpdateInventory()
    {
        ropeText.text = ""+inventory.Ropes;
        bbTrapText.text = "" + inventory.BrokenBearTraps;
        vineText.text = "" + inventory.Vines;
        branchText.text = "" + inventory.ThornyBranches;
    }



}
