using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public PlayerMovement PlayerMovement;
    [SerializeField] string saveFolder;

    public PlayerInventory Inventory {get; set;}

    void Update() {
        if(Input.GetKeyDown("0")) {
            SaveSystem.Save(saveFolder);
        }

        if (Input.GetKeyDown("1")) {
            SaveSystem.Load(saveFolder);
        }
    }

    public void Save() {
        
    }

}
