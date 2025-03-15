using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] Sprite empty;
    [SerializeField] Sprite full;

    [SerializeField] Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void Die()
    {
        image.sprite = empty;
    }

    public void Revive()
    {
        image.sprite = full;
    }
}
