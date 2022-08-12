using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementSystem : MonoBehaviour
{
    private float enemiesKilled = 0;
    // Start is called before the first frame update
    void Start()
    {
        AchievementManager.instance.SetAchievementProgress("Killer", enemiesKilled);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            AchievementManager.instance.AddAchievementProgress("Killer", 1.0f);
        }

        

    }
}
