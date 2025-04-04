using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{

    // Inventory is represented as an array of integers.
    // Each item in the game is assigned an integer ID, so the value at index ID is the number of that item the player has.
    public int[] inventory = {0, 0, 0, 0, 0};
    public int money = 100;

    void Update()
    {
        // Update the player's information in InfoBank
        InfoBank.Instance.playerInventory = inventory;
        InfoBank.Instance.playerMoney = money;

        if (Input.GetKeyUp(KeyCode.T))
        {
            if (SceneManager.GetActiveScene().name == "Present") {
                SceneManager.LoadScene(sceneName:"Not Present");
            }
            else {
                SceneManager.LoadScene(sceneName:"Present");
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            SceneManager.LoadScene(sceneName:"Shop");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object is an item
        if (other.gameObject.tag == "Item") {

            // Add the item to your inventory, and remove it from the scene.
            Item item = other.gameObject.GetComponent<Item>();
            inventory[item.item_id]++;
            Destroy(other.gameObject);
        }
    }

}
