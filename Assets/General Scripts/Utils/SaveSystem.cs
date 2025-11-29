using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData {
        public PlayerSaveData playerData;
    }

    public static string SaveFileName(string folder) {
        //HAVEN'T CHECKED IF FOLDER EXISTS YET SO THIS WILL BREAK
        string saveFile = Application.persistentDataPath + "/" + folder + "/save" + ".save";
        return saveFile;
    }

    public static void Save(string folder) {
        HandleSaveData();

        File.WriteAllText(SaveFileName(folder), JsonUtility.ToJson(_saveData, true));
    }

    public static void HandleSaveData() {
        GameManager.Instance.PlayerMovement.Save(ref _saveData.playerData);
    }

    public static void Load(string folder) {
        string saveContent = File.ReadAllText(SaveFileName(folder));
        if (saveContent == null) {
            Debug.Log("No save file found!");
            return;
        }
        _saveData = JsonUtility.FromJson<SaveData>(saveContent);
        HandleLoadData();
    }

    public static void HandleLoadData() {
        GameManager.Instance.PlayerMovement.Load(_saveData.playerData);
    }
}
