using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMode : MonoBehaviour
{
    [SerializeField] private Dialogue_Set imTooOld;
    [SerializeField] private Dialogue_Set sinceStart;
    [SerializeField] private Dialogue_Set warning;
    [SerializeField] private Dialogue_Set howIknow;
    [SerializeField] private Dialogue_Set ahShit;

    private void Start()
    {
        warning.SetDialogueID(1);
        ahShit.SetDialogueID(2);

        imTooOld?.sendDialogue();
        sinceStart?.sendDialogue();
        warning?.sendDialogue();
        howIknow?.sendDialogue();
        ahShit?.sendDialogue();
    }
    private void Update()
    {







    }


}