using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : Dictionary<string, Dictionary<int, Dictionary<string, int>>> {

}
public class SaveLoad : MonoBehaviour {

    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;
    private string pathSuffix = "-save-game-data.json";
    public ProfileNameData profileName;

    public SaveData LoadProfileSaveData() {
        string path = $"/{profileName.savedName}{pathSuffix}";
        string location = Application.persistentDataPath + path;
        if (File.Exists(location)) {
            SaveData profileSaveData = DataService.LoadData<SaveData>(path, EncryptionEnabled);
            Debug.Log("GameFileFound");
            return profileSaveData;
        } else {
            SaveData profileSaveData = InitializeData();
            Debug.Log("CreatingGameFile");
            return profileSaveData;
        }
    }

    public SaveData InitializeData() {
        string season = "Summer";
        int level = 0;
        int steps = 0;
        SaveData newSaveData = new SaveData {
            {season, new Dictionary<int, Dictionary<string, int>> {
                {level, new Dictionary<string, int> {
                    {"Steps: ", steps }
                } }
            } }
        };
        Save(newSaveData);
        return newSaveData;
    }

    public void Save(SaveData levelInfo) {
        string path = $"/{profileName.savedName}{pathSuffix}";
        if (DataService.SaveData(path, levelInfo, EncryptionEnabled)) {
            Debug.Log("Saved Successfully");

        } else {
            Debug.LogError("Could not save file! Show something on the UI about it!");
        }

    }
}
