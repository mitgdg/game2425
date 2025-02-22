using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int[] inventory = {0, 0, 0, 0, 0};

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        // Debug.Log("Bup");
        // Check if the other object is an item
        if (other.gameObject.tag == "Item") {

            // Add the item to your inventory
            Item item = other.gameObject.GetComponent<Item>();
            inventory[item.item_id]++;
            
            // Destroy the object
            Destroy(other.gameObject);
        }
    }

}
