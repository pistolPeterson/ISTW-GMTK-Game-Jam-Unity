using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] [Range(1.01f, 10.01f)] private float flashlightDrainRate;
    [SerializeField] TextMeshProUGUI flashlightText;
    [SerializeField] TextMeshProUGUI flashlightisOnText;
    private bool isOn;
    private float flashlightPower = 100;
    private float time;
    private float flashLightRechargeRate;
    private DayNightStateMachine dnsm;

    [Header("Audio Stuff")] 
    [SerializeField] private AudioClip toggleClip;
    [SerializeField] private AudioClip brokenLightClip;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        flashlight.SetActive(false);
        isOn = false;
        time = 0;
        flashlightPower = 100;
        flashLightRechargeRate = flashlightDrainRate / 2;
        dnsm = FindObjectOfType<DayNightStateMachine>();
    }

    private void Update()
    {
        time += Time.deltaTime;




        if (time > 0.5f)
        {
            Debug.Log("inside timer? ");
            if (dnsm.GetDayNightState() == DayNightEnum.DAY)
            {
                //Debug.Log("its day time my dudes " + flashlightPower);
                flashlightPower += 1.75f;
                if (flashlightPower >= 100)
                    flashlightPower = 100;
            }



            if (flashlightPower > 0 && isOn)
            {
                Debug.Log("We stay draining");
                flashlightPower -= (1.0f * flashlightDrainRate);
            }


            time = 0;
        }
        flashlightText.text = "FlashLight Power: " + flashlightPower + "% ";

        if (flashlightPower <= 0)
        {
            flashlight.SetActive(false);
            flashlightText.text = "FlashLight Power: 0% ";
            flashlightisOnText.text = "Flashlight is Off";
        }
       

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            ToggleFlashlight();
        }
    }

    public void ToggleFlashlight()
    {
        isOn = !isOn;
        if (flashlightPower >= 00.01f)
            PlayToggleSound();
        else
            PlayBrokeSound();


        flashlight.SetActive(isOn);

        if(isOn == true)
        {
            flashlightisOnText.text = "Flashlight is On"; 
        }
        else
        {
            flashlightisOnText.text = "Flashlight is Off";
        }
    }

    private void PlayToggleSound()
    {
        //randomize ssound
        RandomizeSound();
        audioSource.PlayOneShot(toggleClip);
    }
    private void PlayBrokeSound()
    {
        //randomize ssound
        RandomizeSound();
        audioSource.PlayOneShot(brokenLightClip);
    }

    private void RandomizeSound()
    {
        audioSource.volume = Random.Range(0.75f,0.9f ); 
        audioSource.pitch = Random.Range(0.97f, 1.03f);
    }

}
