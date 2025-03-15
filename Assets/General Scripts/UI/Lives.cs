using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] Heart[] hearts = new Heart[9];
    [SerializeField] int numActiveHearts = 6;   //1 indexed
    [SerializeField] int currHeartNum = 3;  // curr num of alive hearts

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHearts();
    }

    public void AddHeart()
    {
        hearts[numActiveHearts].gameObject.SetActive(true);
        numActiveHearts++;
        //currHeartNum = numActiveHearts; //grant full lives
        currHeartNum++;
        UpdateHearts();
    }

    public void KillHeart()
    {
        if (currHeartNum == 1) print("girl u dead fr");
        currHeartNum -= 1;
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= numActiveHearts)
            {
                hearts[i].gameObject.SetActive(false);
            }
            if (i < currHeartNum) hearts[i].Revive();
            else hearts[i].Die();
        }

    }
}
