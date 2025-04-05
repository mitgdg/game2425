using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    private TextMeshProUGUI moneyText;

    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (InfoBank.Instance != null)
        {
            moneyText.text = $"Money: ${InfoBank.Instance.playerMoney}";
        }
    }
}
