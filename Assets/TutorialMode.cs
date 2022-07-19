using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMode : MonoBehaviour
{
    [SerializeField] private Dialogue_Set imTooOld;
    [SerializeField] private Dialogue_Set sinceStart;
    [SerializeField] private Dialogue_Set warning;
    [SerializeField] private Dialogue_Set howIknow;
    [SerializeField] private Dialogue_Set ahShit;

    private void Start()
    {
        imTooOld?.sendDialogue();
        sinceStart?.sendDialogue();
        warning?.sendDialogue();
        howIknow?.sendDialogue();
        ahShit?.sendDialogue();
    }
    private void Update()
    {

    }


    public void StartGame()
    {
        //change music state?
        //StartCoroutine(FindObjectOfType<MusicMotor>().changeState(FindObjectOfType<DayMusicState>()));
        StartCoroutine(LoadScene2());
    }

    public IEnumerator LoadScene2()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

}