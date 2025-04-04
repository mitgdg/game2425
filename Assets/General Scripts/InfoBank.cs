using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoBank : Singleton<InfoBank>
{
    // This class generates an object instance that holds information about the game state that persists between scene changes.
    // public static InfoBank instance;

    // All tracked information fields are listed here
    public int[] playerInventory = {};
    public int playerMoney = -1;
    public string currentScene = "";
    public string lastScene = "";

    // Initialize the instance when the game starts
    override protected void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Pass information to relevant GameObjects when the scene changes
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        string newScene = scene.name;
        lastScene = currentScene;
        currentScene = newScene;
        if (scene.name == "Present" || scene.name == "Not Present") {
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            PlayerInventory invScript = player.GetComponent<PlayerInventory>();
            if (playerInventory.Length != 0) {
                // Debug.Log("Putting InfoBank inventory into player inventory!");
                invScript.inventory = playerInventory;
            }
            if (playerMoney != -1) {
                invScript.money = playerMoney;
            }
        }
    }
}
