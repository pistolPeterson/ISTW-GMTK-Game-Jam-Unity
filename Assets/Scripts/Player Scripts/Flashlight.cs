using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] [Range(1.01f, 10.01f)] private float flashlightDrainRate;
    [SerializeField] TextMeshProUGUI flashlightText;
    [SerializeField] private Image flashlightImgHolder;
    [SerializeField] private Sprite flashOn;
    [SerializeField] private Sprite flashOff;
    private bool isOn;
    private float flashlightPower = 100;
    private float time;
    private float flashLightRechargeRate;
   
    private ProgressBar progressBar;
   

    private DayNightStateMachine dnsm;
    private PlayerHealth pm; 
    private void Start()
    {
        progressBar = FindObjectOfType<ProgressBar>();
        progressBar.BarValue = 100;
        flashlightImgHolder.sprite = flashOff;
        flashlight.SetActive(false);
        isOn = false;
        time = 0;
        flashlightPower = 100;
        flashLightRechargeRate = flashlightDrainRate / 2;
        dnsm = FindObjectOfType<DayNightStateMachine>();
        pm = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            //Debug.Log("inside timer? ");
            if (dnsm.GetDayNightState() == DayNightEnum.DAY)
            {
                flashlightPower += 1.75f;
                if (flashlightPower >= 100)
                    flashlightPower = 100;
            }



            if (flashlightPower > 0 && isOn)
            {
                
                flashlightPower -= (1.0f * flashlightDrainRate);
            }


            time = 0;
        }


       // flashlightText.text =  flashlightPower + "% ";
        progressBar.BarValue = flashlightPower;
        if (flashlightPower <= 0)
        {
            flashlight.SetActive(false);
           // flashlightText.text = "0% ";
            flashlightImgHolder.sprite = flashOff;
        }
       

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            ToggleFlashlight();
        }
    }

    public void ToggleFlashlight()
    {
        if (!pm.isAlive) return;

        isOn = !isOn;
        if (flashlightPower >= 00.01f)
            PlayToggleSound();
        else
            PlayBrokeSound();


        flashlight.SetActive(isOn);

        if(isOn == true)
        {
            flashlightImgHolder.sprite = flashOn;
        }
        else
        {
            flashlightImgHolder.sprite = flashOff;
        }
    }

    private void PlayToggleSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Flashlight/Flashlight Toggle", transform.position);

    }
    private void PlayBrokeSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Items/Flashlight/Flashlight Broke", transform.position);

    }



}
