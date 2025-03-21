using UnityEngine;
using TMPro;

public class BuyItem : MonoBehaviour {

    public int itemId;
    public int price;

	void Start () {
		// Set button text
		TextMeshProUGUI btnText = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
		if (itemId == -1) {
			btnText.text = $"Receive ${price}";
		}
		else {
			btnText.text = $"Item ID: {itemId}\nPrice: ${price}";
		}
	}

	public void MakePurchase() {
		if (InfoBank.instance != null) {
			if (InfoBank.instance.playerMoney >= price && itemId != -1) {
				InfoBank.instance.playerInventory[itemId]++;
				InfoBank.instance.playerMoney -= price;
				Debug.Log($"Bought Item {itemId}!");
			}
			else if (itemId == -1) {
				InfoBank.instance.playerMoney += price;
				Debug.Log($"Free Money!");
			}
			else {
				Debug.Log("Not enough money.");
			}
        }
	}
}
