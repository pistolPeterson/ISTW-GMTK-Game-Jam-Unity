using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightStateMachine : MonoBehaviour
{
    [SerializeField] private DayNightScript dayNight;
    private DayNightEnum dayNightState;


    private void Start()
    {
        dayNight = GetComponent<DayNightScript>();
        dayNightState = DayNightEnum.DAY;
    }

    public DayNightEnum GetDayNightState()
    { return dayNightState; }

    private void Update()
    {
        //Debug.Log(dayNightState);
        switch (dayNightState)
        {
            case DayNightEnum.DAY:
                if (!dayNight.sunIsOn)
                    dayNightState = DayNightEnum.BEGIN_NIGHT;
                break;
            case DayNightEnum.BEGIN_NIGHT:
                dayNight.PostBeginNightEvent();
                dayNightState = DayNightEnum.NIGHT;
                break;
            case DayNightEnum.NIGHT:
                if (dayNight.sunIsOn)
                    dayNightState = DayNightEnum.BEGIN_DAY;
                break;
            case DayNightEnum.BEGIN_DAY:
                dayNight.PostBeginDayEvent();
                dayNightState = DayNightEnum.DAY;
                break;
        }
    }
}

public enum DayNightEnum
{
    NONE,
    BEGIN_DAY,
    DAY,
    BEGIN_NIGHT,
    NIGHT
}