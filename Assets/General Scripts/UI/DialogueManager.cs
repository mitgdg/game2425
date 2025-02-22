using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class DialogueManager : Singleton<DialogueManager>
{

    //[SerializeField] private Fungus.DialogInput _dialogInput;
    [SerializeField] private Fungus.Writer _writer;
    [SerializeField] private Fungus.Flowchart flowchart;

    public void ChangeDialogInputClickMode(ClickMode clickMode)
    {
        DialogInput[] dialogInputs = GameObject.FindObjectsByType(typeof(DialogInput), FindObjectsSortMode.None) as DialogInput[];
        foreach (DialogInput dialogInput in dialogInputs)
        {
            dialogInput.clickMode = clickMode;
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu") PlayerPrefs.SetString("currScene", SceneManager.GetActiveScene().name);
    }

    public void ChangeWritingSpeed(float f)
    {
        _writer.ChangeWritingSpeed(f);
    }


    public void RunBlock(string blockName)
    {
        flowchart.ExecuteBlock(blockName);
    }

    public void AddToDelusion()
    {
        PlayerPrefs.SetInt("delusion", PlayerPrefs.GetInt("delusion", 0) + 1);
    }

    public void AddToDeath()
    {
        PlayerPrefs.SetInt("death", PlayerPrefs.GetInt("death", 0) + 1);
    }

    public void ChangeToEnding()
    {
        if (PlayerPrefs.GetInt("death") > PlayerPrefs.GetInt("delusion"))
        {
            SceneManager.LoadScene("Death End");
        }
        else SceneManager.LoadScene("Delusion End");
    }

}
