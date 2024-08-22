using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using Newtonsoft.Json;
using System;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using System.IO;
using Unity.VisualScripting;
using System.Net;

//public class SaveData : Dictionary<string, Dictionary<string, Dictionary<string, string>>> {

//}

public class TestDataScript : MonoBehaviour
{
    public TextMeshProUGUI saveTextField;
    public TextMeshProUGUI loadTextField;
    public TMP_InputField seasonTxt;
    public TMP_InputField levelNum;
    public TMP_InputField stepsNum;

    public SceneInfo dataToSave;
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;
    public Dictionary<string, Dictionary<string, Dictionary<string, string>>> newTestData;

    public void GetData() {
        string season = seasonTxt.text;
        int level = 0;
        int steps = 0;
        SaveStart(season, level, steps);
    }

    public void SaveStart(string mainKey, int newLevelKey, int newStepsValue) {
        string path = "/player-stats.json";
        string location = Application.persistentDataPath + path;
        if (File.Exists(location)) {
            SaveData newTestData = DataService.LoadData<SaveData>("/player-stats.json", EncryptionEnabled);
            if (newTestData.ContainsKey(mainKey)) {
                var levelDict = newTestData[mainKey];
                levelDict[newLevelKey] = new Dictionary<string, int> {
                { "Steps", newStepsValue }
            };
                Save(newTestData);
            } else {
                newTestData[mainKey] = new Dictionary<int, Dictionary<string, int>> {
                {
                    newLevelKey, new Dictionary<string, int>
                {
                    { "Steps", newStepsValue }
                }
                }
            };
                Save(newTestData);
            }
        } else {
            string season = mainKey;
            int level = newLevelKey;
            int steps = newStepsValue;
            DataBuild(season, level, steps);
        }

    }
    public void DataBuild(string season, int level, int steps) {
        SaveData newTestData = new SaveData {
            {season, new Dictionary<int, Dictionary<string, int>> {
                {level, new Dictionary<string, int> {
                    {"Steps: ", steps }
                } }
            } }
        };
        Save(newTestData);
    }

    public void DeleteSave() {
        string path = "/player-stats.json";
        string location = Application.persistentDataPath + path;
        if (File.Exists(location)) {
                Debug.Log("Deleting file");
                File.Delete(location);
        } else {
                Debug.Log("No file to delete");
        }
    }

    public void Save(SaveData levelInfo) {
        if (DataService.SaveData("/player-stats.json", levelInfo, EncryptionEnabled)) {
            Debug.Log("Saved Successfully");
            saveTextField.SetText(JsonConvert.SerializeObject(levelInfo));

        } else {
            Debug.LogError("Could not save file! Show something on the UI about it!");
            saveTextField.text = "<color=#ff0000>Error saving data!</color>";
        }

    }

    public void TestMethod() {
        Debug.Log("Hello");
    }
}

