using UnityEngine;
using TMPro;
using Fungus;
using System.Collections;

namespace TeamMelon
{
    public class PopupText : MonoBehaviour   //I LOVE COPY-PASTING RAAAHH x2
    {

        [SerializeField] float xPos;
        [SerializeField] float yPos;
        //[SerializeField] float ogXPos;
        //[SerializeField] float ogYPos;
        [SerializeField] bool joke = false;
        [SerializeField] Transform player;
        [SerializeField] Flowchart flowchart;
        [SerializeField] bool isInRange;
        [SerializeField] private KeyCode interactKey;
        [SerializeField] string action = "open";
        //[SerializeField] Door otherDoor;

        [SerializeField] TMP_Text interactText;
        [SerializeField] float addY = 3.0f;
        private TMP_Text tempInteractText;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isInRange && Input.GetKeyDown(interactKey))
            {
                if (joke)
                {
                    flowchart.ExecuteBlock("no open door");
                    return;
                }
                //if(!player.GetCanInteract()) return;
                //tempInteractText.enabled = false;
                flowchart.ExecuteBlock("fade2");
                //ogXPos = player.position.x;
                //ogYPos = player.position.y;

                StartCoroutine(WaitThenMove());

            }
        }

        IEnumerator WaitThenMove()
        {
            yield return new WaitForSeconds(1);
            player.position = new Vector2(xPos, yPos);
            //yield return null;
        }

        //public void SetTargetPos(float x, float y) {    //for saving your position lol
        //    xPos = x;
        //    yPos = y;
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Debug.Log("Entered");
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                if (tempInteractText == null)
                {
                    tempInteractText = Instantiate(interactText.gameObject, transform.position, Quaternion.identity).GetComponent<TMP_Text>();
                    //tempInteractText.transform.lossyScale = Vector3.one;
                    tempInteractText.transform.SetParent(transform, true);
                    tempInteractText.gameObject.SetActive(true);
                    tempInteractText.transform.position += new Vector3(0, addY, 0);
                }
                tempInteractText.enabled = true;
                tempInteractText.text = interactKey + " to " + action;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isInRange = false;
            if (tempInteractText != null) tempInteractText.enabled = false;
            //Debug.Log("Exited");
        }

    }
}
