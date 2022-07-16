using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUI : MonoBehaviour
{
    public float timeBeforeResetScene = 2.5f;
    public GameObject resetButton;

    private PlayerHealth playerHealth; 
    // Start is called before the first frame update
    void Start()
    {
        resetButton.SetActive(false);
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerHealth.isAlive)
            resetButton.SetActive(true);
    }

    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(timeBeforeResetScene);
        SceneManager.LoadSceneAsync(0);
    }
    public void ResetGameForButton() { StartCoroutine(ResetGame()); }
}
