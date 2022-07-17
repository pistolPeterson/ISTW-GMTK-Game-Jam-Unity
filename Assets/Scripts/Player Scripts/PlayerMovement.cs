using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(1.0f, 12.5f)] private float playerSpeed;
    [SerializeField] [Range(248f, 512f)] private float rotSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isFreeze;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        isFreeze = false;
        rb = GetComponent<Rigidbody2D>();
        animator?.SetTrigger("stop Trigger");
    }

    private void Update()
    {
        //input 
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
       
    }

    private void FixedUpdate()
    {
        if (isFreeze) return;
        //movement
        if(rb!= null)
        rb.MovePosition(rb.position + (movement * playerSpeed * Time.fixedDeltaTime));

        if (movement != Vector2.zero)
        {
            animator?.SetTrigger("moveTrigger");
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
        }
        else
            animator?.SetTrigger("stop Trigger");

    }


    public void FreezePlayer()
    {
        isFreeze = true;
    }

    public void UnFreezePlayer()
    {
        isFreeze = false;
    }

    public bool IsFreeze
        { get { return isFreeze; } }
}
