using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;
    public Tilemap obstacle;
    public LayerMask unmove;

    


    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        
        Vector3Int obstacleMap = obstacle.WorldToCell(movePoint.position - new Vector3(0, 0.5f, 0) + new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f));


        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && obstacle.GetTile(obstacleMap) == null )
        {
           
            if (Input.GetAxisRaw("Horizontal") != 0f && obstacle.GetTile(obstacleMap) == null)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, unmove)){
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    animator.SetFloat("horizontal",Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
                }
                
            }

            if (Input.GetAxisRaw("Vertical") != 0f && obstacle.GetTile(obstacleMap) == null)
            {   
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, unmove)){
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    animator.SetFloat("horizontal",Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
                }
                
            }
            
            
        }

        animator.SetFloat("speed", Mathf.Sqrt((Input.GetAxisRaw("Horizontal")*Input.GetAxisRaw("Horizontal")) + (Input.GetAxisRaw("Vertical")*Input.GetAxisRaw("Vertical"))));

    }

    void FixedUpdate(){
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(movePoint.position - new Vector3(0, 0.5f, 0) + new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f),0.2f);
    }
}
