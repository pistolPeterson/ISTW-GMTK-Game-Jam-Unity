using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Transform targetPos;
    [SerializeField] LayerMask colliderMask;

    // Start is called before the first frame update
    void Start()
    {
        targetPos.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos.position) == 0.0f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {

                if (!Physics2D.OverlapCircle(targetPos.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, colliderMask))
                {
                    targetPos.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {

                if (!Physics2D.OverlapCircle(targetPos.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, colliderMask))
                {
                    targetPos.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }


    }
}
