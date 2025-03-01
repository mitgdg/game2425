using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoBank : MonoBehaviour
{
    // This class generates an object instance that holds information about the game state that persists between scene changes.
    // TODO: Integrate InfoBank with Singleton class (I don't know how Singleton works yet, but it seems to have a similar purpose to InfoBank.)
    public static InfoBank instance;

    // All tracked information fields are listed here
    public int[] playerInventory = null;
    public int playerMoney = -1;

    // Initialize the instance when the game starts
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Pass information to relevant GameObjects when the scene changes
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
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
