using UnityEngine;
using System.Collections;
using TMPro;

public class RatMovement : MonoBehaviour
{

    [SerializeField] int[] xPoints;
    [SerializeField] int[] yPoints;

    [SerializeField] int currPt = 0;
    [SerializeField] float speed = 2f;
    [SerializeField] Vector3 jumpAcceleration = new Vector3(0, -5, 0);
    private Vector3 jumpVelocity = new Vector3(0, 0, 0);
    [SerializeField] Vector3 initialJumpVelocity;
    private float jumpY;
    [SerializeField] Transform transform;

    [SerializeField] bool playerInCircle;
    [SerializeField] Transform player;

    [SerializeField] TMP_Text interactText;
    [SerializeField] float addY = 1.5f;
    private TMP_Text tempInteractText;

    private bool justDetectPlayer = false;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        print("player spotted!!");
        playerInCircle = true;
        justDetectPlayer = true;
        jumpY = transform.position.y;
        jumpVelocity = initialJumpVelocity;
        if (tempInteractText == null)
        {
            tempInteractText = Instantiate(interactText.gameObject, transform.position, Quaternion.identity).GetComponent<TMP_Text>();
            //tempInteractText.transform.lossyScale = Vector3.one;
            tempInteractText.transform.SetParent(transform, true);
            tempInteractText.gameObject.SetActive(true);
            tempInteractText.transform.position += new Vector3(0, addY, 0);
        }
        tempInteractText.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        print("player left!");
        playerInCircle = false;
        if (tempInteractText != null)
        {
            tempInteractText.enabled = false;
        }
    }

    public void Move()
    {
        //check: are you at this point?
        if (transform.position.x == xPoints[currPt] && transform.position.y == yPoints[currPt])
        {
            currPt++;
            if (currPt >= xPoints.Length) currPt = 0;
        }

        if (!playerInCircle) transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPoints[currPt], yPoints[currPt], 0), speed * Time.deltaTime);
        else
        {
            if (justDetectPlayer)
            {
                jumpVelocity += jumpAcceleration * Time.deltaTime;
                transform.position += jumpVelocity * Time.deltaTime;
                if (transform.position.y <= jumpY)
                {
                    justDetectPlayer = false;
                    jumpVelocity = new Vector3(0, 0, 0);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }

    }
}
