using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveShop : MonoBehaviour
{
    // This is a temporary script for leaving the shop. It will be replaced or modified later.

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (InfoBank.Instance != null) {
                SceneManager.LoadScene(sceneName:InfoBank.Instance.lastScene);
            }
            else {
                SceneManager.LoadScene(sceneName:"Present");
            }
        }
    }
}
