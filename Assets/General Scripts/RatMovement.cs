using UnityEngine;
using System.Collections;

public class RatMovement : MonoBehaviour
{
    
    [SerializeField] int[] xPoints;
    [SerializeField] int[] yPoints;

    [SerializeField] int currPt = 0;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform transform;

    [SerializeField] bool playerInCircle;
    [SerializeField] Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = this.gameObject.transform;  
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Player") return;
        print("player spotted!!");
        playerInCircle = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag != "Player") return;
        print("player left!");
        playerInCircle = false;
    }

    public void Move() {
        //check: are you at this point?
        if(transform.position.x == xPoints[currPt] && transform.position.y == yPoints[currPt]) {
            currPt++;
            if(currPt >= xPoints.Length) currPt = 0;
        }

        if(!playerInCircle) transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPoints[currPt], yPoints[currPt], 0), speed * Time.deltaTime);
        else {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

    }
}
