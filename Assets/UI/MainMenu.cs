using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {

       StartCoroutine( FindObjectOfType<MusicMotor>().changeState(FindObjectOfType<DeathAmbienceState>()));
        StartCoroutine(LoadScene1());
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public IEnumerator LoadScene1()
    {

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }

}
