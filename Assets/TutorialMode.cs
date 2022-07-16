using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMode : MonoBehaviour
{
    [SerializeField] private Dialogue_Set imTooOld;
    [SerializeField] private Dialogue_Set sinceStart;
    [SerializeField] private Dialogue_Set warning;
    public TutorialState state;

    private bool anyKeyPressed = false; 
   
    private void Start()
    {
        imTooOld?.sendDialogue();
        sinceStart?.sendDialogue();
        state = TutorialState.MOVE_WITH_ARROW_KEYS; 
    }
    private void Update()
    {
        switch(state)
        {
            case TutorialState.MOVE_WITH_ARROW_KEYS:

                break;
            case TutorialState.PICK_UP_ITEMS_D:
                //say something 
                
                state = TutorialState.PICK_UP_ITEMS;
                break;
          
                //

        }







        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            anyKeyPressed = true;

    }


    public void moveWithArrowKeys()
    {
        if (AnyKeyPressed())
            state = TutorialState.PICK_UP_ITEMS; 
    }

    public bool AnyKeyPressed()
    {
        return anyKeyPressed; 
    }

}
public enum TutorialState
{
    NONE, 
    MOVE_WITH_ARROW_KEYS,
    PICK_UP_ITEMS_D,
    PICK_UP_ITEMS

}
