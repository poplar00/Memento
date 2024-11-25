using UnityEngine;

public class keyFollower : MonoBehaviour
{
    private bool isFollowing;
    public float followSpeed = 3f;
    public Transform followTarget;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing){
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
    
        if (other.tag == "Player"){
            if(!isFollowing){
                MovementPlayer thePlayer = FindFirstObjectByType<MovementPlayer>();
                isFollowing = true;
                thePlayer.followingKey = this;
            }
        }
    }
}
