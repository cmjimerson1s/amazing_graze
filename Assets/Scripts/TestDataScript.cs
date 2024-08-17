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
    [SerializeField] string NameText;
    public Dictionary<string, Dictionary<string, Dictionary<string, int>>> testData;
    public Dictionary<string, Dictionary<string, Dictionary<string, string>>> newTestData;


    public void TestDataStructure() {
        testData = new Dictionary<string, Dictionary<string, Dictionary<string, int>>> {
            {"Summer", new Dictionary<string, Dictionary<string, int>> {
                {$"Level {1}", new Dictionary<string, int> {
                    {"Steps", 1 }
                } }
            } }
        };
    }

    public void CreateDataStructure(string season, int level, int steps) {
        if (testData == null) {
            TestDataStructure();
        }
        TestDataInitialize(season, level, steps);
        SerializeJson();

    }
    public void SerializeJson() {
        if (DataService.SaveData("/player-stats.json", testData, EncryptionEnabled)) {
            Debug.Log("Saved Successfully");
            saveTextField.SetText(JsonConvert.SerializeObject(testData));

        } else {
            Debug.LogError("Could not save file! Show something on the UI about it!");
            saveTextField.text = "<color=#ff0000>Error saving data!</color>";
        }
    }
    
    public void DeserializeJson() {
        Dictionary<string, Dictionary<string, Dictionary<string, string>>> newTestData = DataService.LoadData<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>("/player-stats.json", EncryptionEnabled);
        loadTextField.SetText(JsonConvert.SerializeObject(newTestData));
    }

   public void TestDataInitialize(string season, int level, int steps) {
        testData = new Dictionary<string, Dictionary<string, Dictionary<string, int>>> {
            {season, new Dictionary<string, Dictionary<string, int>> {
                {$"Level {level}", new Dictionary<string, int> {
                    {"Steps", steps }
                } }
            } }
        };
    }

    public void GetData() {
        string season = seasonTxt.text;
        string level = levelNum.text;
        string steps = stepsNum.text;
        SaveStart(season, level, steps);
    }

    public void DataBuild(string season, string level, string steps) {
        newTestData = new Dictionary<string, Dictionary<string, Dictionary<string, string>>> {
            {season, new Dictionary<string, Dictionary<string, string>> {
                {level, new Dictionary<string, string> {
                    {"Steps: ", steps }
                } }
            } }
        };
        if (DataService.SaveData("/player-stats.json", newTestData, EncryptionEnabled)) {
            Debug.Log("Saved Successfully");
            saveTextField.SetText(JsonConvert.SerializeObject(newTestData));

        } else {
            Debug.LogError("Could not save file! Show something on the UI about it!");
            saveTextField.text = "<color=#ff0000>Error saving data!</color>";
        }
    }

    public void SaveStart(string mainKey, string newLevelKey, string newStepsValue) {
        string path = "/player-stats.json";
        string location = Application.persistentDataPath + path;
        if (File.Exists(location)) {
            SaveData newTestData = DataService.LoadData<SaveData>("/player-stats.json", EncryptionEnabled);
            if (newTestData.ContainsKey(mainKey)) {
                var levelDict = newTestData[mainKey];
                levelDict[newLevelKey] = new Dictionary<string, string> {
                { "Steps", newStepsValue }
            };
                if (DataService.SaveData("/player-stats.json", newTestData, EncryptionEnabled)) {
                    Debug.Log("Saved Successfully");
                    saveTextField.SetText(JsonConvert.SerializeObject(newTestData));

                } else {
                    Debug.LogError("Could not save file! Show something on the UI about it!");
                    saveTextField.text = "<color=#ff0000>Error saving data!</color>";
                }
            } else {
                newTestData[mainKey] = new Dictionary<string, Dictionary<string, string>> {
                {
                    newLevelKey, new Dictionary<string, string>
                {
                    { "Steps", newStepsValue }
                }
                }
            };
                if (DataService.SaveData("/player-stats.json", newTestData, EncryptionEnabled)) {
                    Debug.Log("Saved Successfully");
                    saveTextField.SetText(JsonConvert.SerializeObject(newTestData));

                } else {
                    Debug.LogError("Could not save file! Show something on the UI about it!");
                    saveTextField.text = "<color=#ff0000>Error saving data!</color>";
                }
            }
        } else {
            string season = mainKey;
            string level = newLevelKey;
            string steps = newStepsValue;
            DataBuild(season, level, steps);
        }

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

    class SaveData : Dictionary<string, Dictionary<string, Dictionary<string, string>>> {

    }
}

