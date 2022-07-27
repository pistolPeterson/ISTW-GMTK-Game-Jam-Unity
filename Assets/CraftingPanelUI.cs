using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CraftingPanelUI : MonoBehaviour
{

    [SerializeField] private GameObject fullCraftingPanelUI;

    [SerializeField] private Image bigImage;

    [SerializeField] private Sprite bearTrapSprite;
    [SerializeField] private Sprite bowArrowTrapSprite;
    [SerializeField] private Sprite branchTrapSprite;


    private int currentlySelectedItem;
    private bool isOpen; 

    public static event Action OnCraftButtonClicked;
    // Start is called before the first frame update
    void Start()
    {
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
    }
    public void TogglePanel()
    {
        isOpen = !isOpen;
        fullCraftingPanelUI.SetActive(isOpen);
    }


    public void ClickOnImage(int i)
    {//maybe if you have enough materials, you can get ready to craft 
        //if not, then it shows what items you need

        switch(i)
        {
            case 0:
                bigImage.sprite = bearTrapSprite;
                break;
            case 1:
                bigImage.sprite = bowArrowTrapSprite;
                break;
            case 2:
                bigImage.sprite = branchTrapSprite;
                break;


        }

        currentlySelectedItem = i;
    }


    public void CraftButton()
    {
        //post event with f = 0
        Debug.Log("craftikng?");
        OnCraftButtonClicked?.Invoke();
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
