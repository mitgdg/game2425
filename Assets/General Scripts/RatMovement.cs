using UnityEngine;
using System.Collections;

public class RatMovement : MonoBehaviour
{
    
    [SerializeField] int[] xPoints;
    [SerializeField] int[] yPoints;

    [SerializeField] int currPt = 0;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform transform;

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

    public void Move() {
        //check: are you at this point?
        if(transform.position.x == xPoints[currPt] && transform.position.y == yPoints[currPt]) {
            currPt++;
            if(currPt >= xPoints.Length) currPt = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPoints[currPt], yPoints[currPt], 0), speed * Time.deltaTime);

    }
}
