using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField][Range(0.01f, 1.0f)] private float smoothSpeed;
    [SerializeField] private Vector3 offset;


    private void LateUpdate()
    {
        Vector3 desiredPos =target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position,desiredPos,smoothSpeed);    
        transform.position = smoothPos;
    }
}
