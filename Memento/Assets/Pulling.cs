using UnityEngine;
using UnityEngine.InputSystem;

public class Pulling : MonoBehaviour
{
    [SerializeField]
    private Transform grabPos;

    [SerializeField]
    private Transform rayPos;

    [SerializeField]
    private float distance = 1f;
    private GameObject meja;
    private int layerIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("unmovable");

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPos.position, transform.right, distance);
        if(hit.collider != null && hit.collider.gameObject.tag == "pullable" && hit.collider.gameObject.layer == layerIndex){
            if(Keyboard.current.spaceKey.wasPressedThisFrame && meja == null){
                meja = hit.collider.gameObject;
                meja.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                meja.transform.position =grabPos.position;
                meja.transform.SetParent(transform);
            }

            else if(Keyboard.current.spaceKey.wasPressedThisFrame){
                meja.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                meja.transform.SetParent(null);
                meja = null;
            }


        }

        Debug.DrawRay(rayPos.position, transform.right * distance);
    
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position +  Vector2.right* transform.localScale.x * distance);
    }

}
