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

public class SaveData : Dictionary<string, Dictionary<string, Dictionary<string, string>>> {

}

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
        string level = levelNum.text;
        string steps = stepsNum.text;
        SaveStart(season, level, steps);
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
                Save(newTestData);
            } else {
                newTestData[mainKey] = new Dictionary<string, Dictionary<string, string>> {
                {
                    newLevelKey, new Dictionary<string, string>
                {
                    { "Steps", newStepsValue }
                }
                }
            };
                Save(newTestData);
            }
        } else {
            string season = mainKey;
            string level = newLevelKey;
            string steps = newStepsValue;
            DataBuild(season, level, steps);
        }

    }
    public void DataBuild(string season, string level, string steps) {
        SaveData newTestData = new SaveData {
            {season, new Dictionary<string, Dictionary<string, string>> {
                {level, new Dictionary<string, string> {
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

}

