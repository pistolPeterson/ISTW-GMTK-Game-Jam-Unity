using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(1.0f, 12.5f)] private float playerSpeed;
    [SerializeField] [Range(248f, 512f)] private float rotSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        //input 
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + (movement * playerSpeed * Time.fixedDeltaTime));

        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
        }
    }
}