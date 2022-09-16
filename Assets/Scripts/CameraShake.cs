using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float shakeTime;
    float shakeMag;

    Vector3 BasePos; 
    // Start is called before the first frame update
    void Start()
    {
        BasePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTime > 0)
        {
            transform.localPosition = (Vector2)BasePos + (Random.insideUnitCircle * shakeMag);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            shakeTime -= Time.deltaTime;
        }
        else
        {
            transform.position = BasePos;
        }


       
    }

    public void ShakeCam(float Timer, float Magnitude)
    {
        shakeTime += Timer;
        shakeMag = Magnitude;
    }

    public void ResetShake()
    {
        shakeTime = 0;
    }
}
