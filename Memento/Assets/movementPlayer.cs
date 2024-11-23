using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
           
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                animator.SetFloat("horizontal",Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Vertical") != 0f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                animator.SetFloat("horizontal",Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
            }
            
            
        }

        animator.SetFloat("speed", Mathf.Sqrt((Input.GetAxisRaw("Horizontal")*Input.GetAxisRaw("Horizontal")) + (Input.GetAxisRaw("Vertical")*Input.GetAxisRaw("Vertical"))));

    }
}
