using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private float timeBeforeResetScene = 1.25f;
    public GameObject resetButton;

   

    [Header("UI for the death panel, achievements, tips, sarcasm etc")]
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private TextMeshProUGUI daySurvivedText;
    [SerializeField] private TextMeshProUGUI enemiesKilledText;


    private PlayerHealth playerHealth;
    private DayNightScript dayNightCycle;

    // Start is called before the first frame update
    void Start()
    {
        deathPanel.SetActive(false);
        resetButton.SetActive(false);
        playerHealth = FindObjectOfType<PlayerHealth>();
        dayNightCycle = FindObjectOfType<DayNightScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerHealth.isAlive)
            resetButton.SetActive(true);
    }


    private void OnEnable()
    {
        PlayerHealth.OnDeath += OpenDeathPanel;
    }

    private void OnDisable()
    {
        PlayerHealth.OnDeath -= OpenDeathPanel;
    }

    public void OpenDeathPanel()
    {
        deathPanel.SetActive(true);
        daySurvivedText.text = "You survived " + dayNightCycle.days + " days.";
        enemiesKilledText.text = FindObjectOfType<Inventory>().GetEnemiesKilled() + " Enemies have succumbed to your traps.";
    }

    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(timeBeforeResetScene);
        SceneManager.LoadSceneAsync(0);
    }
    public void ResetGameForButton() { StartCoroutine(ResetGame()); }
}
