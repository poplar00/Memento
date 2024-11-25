using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    private MovementPlayer thePlayer;
    public SpriteRenderer sr;
    public Sprite doorOpen;
    public bool opened, waiting;

    void Start()
    {
        thePlayer = FindFirstObjectByType<MovementPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waiting){
            if(Vector3.Distance(thePlayer.followingKey.transform.position, transform.position) < 1f){
                waiting = false;
                opened = true;
                sr.sprite = doorOpen;
                thePlayer.followingKey.gameObject.SetActive(false);
                thePlayer.followingKey = null;
            }   
        }

        if(opened && Vector3.Distance(thePlayer.transform.position, transform.position) < 2f){
            SceneManager.LoadSceneAsync("Tutorial_2");
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(thePlayer.followingKey != null){
                thePlayer.followingKey.followTarget = transform;
                waiting = true;
            }
        }
    }
}
