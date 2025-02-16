using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    public int item_id;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0, item_id/4.0f, 0.5f, 1);
    }

    void Update()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(0, item_id/4.0f, 0.5f, 1);
    }
}
