using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; 


public class CraftingPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject fullCraftingPanelUI;

    [SerializeField] private Image bigImage;

    [SerializeField] private Sprite bearTrapSprite;
    [SerializeField] private Sprite bowArrowTrapSprite;
    [SerializeField] private Sprite branchTrapSprite;

    [SerializeField] private TextMeshProUGUI bearTrapAmt;
    [SerializeField] private TextMeshProUGUI bowArrowAmt;
    [SerializeField] private TextMeshProUGUI branchArrowAmt;

    [SerializeField] private TextMeshProUGUI recipeText; 


    private int currentlySelectedItem;
    private bool isOpen;

    private Inventory inv;
   
    public static event Action OnCraftButtonClicked;
    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<Inventory>();
       

        currentlySelectedItem = -1;
        isOpen = false; 
        fullCraftingPanelUI.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            TogglePanel();
        }
        //REFACTOR too much info in update loop, refactor into method

        if(isOpen)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                //edge case 
                if (currentlySelectedItem == 2)//if last item of selected 
                {
                    ClickOnImage(0);
                    currentlySelectedItem = 0;
                }
                else
                {
                    currentlySelectedItem++;
                    ClickOnImage(currentlySelectedItem);
                }
            }


            if(Input.GetKeyDown(KeyCode.W))
            {
                //edge case 
                if (currentlySelectedItem == 0)//if first item of selected 
                {
                    ClickOnImage(2);
                    currentlySelectedItem = 2;
                }
                else
                {
                    currentlySelectedItem--;
                    ClickOnImage(currentlySelectedItem);
                }

            }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                CraftButton();
                TogglePanel();
            }
        }


    }
    public void TogglePanel()
    {
        isOpen = !isOpen;
        fullCraftingPanelUI.SetActive(isOpen);

        if(isOpen == true)
        {
            InitUI();
            ClickOnImage(0);
            Time.timeScale = 0.0f; 

        }
        else 
            Time.timeScale = 1.0f;
    }

    void InitUI()
    {
        bearTrapAmt.text = "" + inv.PotentialBearTraps();
        bowArrowAmt.text = "" + inv.PotentialBowArrowTraps();
        branchArrowAmt.text = "" + inv.PotentialBranchTraps();
    }

    public void ClickOnImage(int i)
    {//maybe if you have enough materials, you can get ready to craft 
        //if not, then it shows what items you need

        switch(i)
        {
            case 0:
                bigImage.sprite = bearTrapSprite;
                recipeText.text = DisplayRecipeText(inv.bearTrapRec);
                break;
            case 1:
                bigImage.sprite = bowArrowTrapSprite;
                recipeText.text = DisplayRecipeText(inv.bowArrowTrapRec);
                break;
            case 2:
                bigImage.sprite = branchTrapSprite;
                recipeText.text = DisplayRecipeText(inv.branchTrapRec);
                break;


        }

        currentlySelectedItem = i;
    }

    private string DisplayRecipeText(TrapRecipe trapRecipe)
    {
        string text = trapRecipe.ropeAmount + "x Ropes\n" +
                      trapRecipe.branchAmount + "x Branches\n" +
                      trapRecipe.vineAmount + "x Vines\n" +
                      trapRecipe.bbearTrapAmount + "x Broken Bear Traps";

        return text;
    }
    public void CraftButton()
    {
        OnCraftButtonClicked?.Invoke();
        InitUI();
        inv.InvokeUIUpdate();
    }

    public int CurrentlySelectedItem() 
    {
        Debug.Log("current slected item tho");
        if (currentlySelectedItem == -1)
            return 0;

        return currentlySelectedItem; 
    }

    //invoked methtod in inventory 
    //gets the 0, if you have enough items to make it
    //close panel, instantiate item

}
