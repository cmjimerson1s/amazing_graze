using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using TMPro;
using static UnityEditor.FilePathAttribute;
using File = System.IO.File;
using Newtonsoft.Json;

public class LevelSelect : MonoBehaviour {
    private IDataService DataService = new JsonDataService();
    private string filePath;
    private bool EncryptionEnabled;
    public TMP_InputField profileOneInput;
    public GameObject SelectButtonOne;
    public TextMeshProUGUI profileOneName;

    void Start() {
        DisableTMPInputs();
        CollectProfileData();

    }

    public void CollectProfileData() {
        string profile = "/user-profiles.json";
        filePath = Application.persistentDataPath + profile;
        if (File.Exists(filePath)) {
            List<string> profileNames = DataService.LoadData<List<string>>(profile, EncryptionEnabled);
            DisplayProfileData(profileNames);
        } else {
            Debug.Log("No file found");
            List<string> profileNames = new List<string>();
            DisplayProfileData(profileNames);
        }
    }

    public void DisplayProfileData(List<string> profileNames) {
        if (profileNames.Count < 1) {
            Debug.Log("No names found");
            profileOneName.SetText("New Game");
        } else {
            profileOneName.SetText($"{profileNames[0]}");
        }
    }

    public void NewGame() {
        string profile = "/user-profiles.json";
        filePath = Application.persistentDataPath + profile;
        if (File.Exists(filePath)) {
            List<string> profileNames = DataService.LoadData<List<string>>(profile, EncryptionEnabled);
            string profileName = profileOneInput.text;
            profileNames.Add(profileName);
            SaveProfile(profileNames);
        } else {
            Debug.Log("No file found");
            List<string> profileNames = new List<string>();
            string profileName = profileOneInput.text;
            profileNames.Add(profileName);
            SaveProfile(profileNames);
        }

    }

    public void SaveProfile(List<string> profileNames) {
        if (DataService.SaveData("/user-profiles.json", profileNames, EncryptionEnabled)) {
            Debug.Log("Saved Successfully");
        } else {
            Debug.LogError("Could not save file! Show something on the UI about it!");
        }

    }

    public void DisableTMPInputs() {
        profileOneInput.gameObject.SetActive(false);
    }

    public void DisableSelectButton() {
        SelectButtonOne.gameObject.SetActive(false);
        profileOneInput.gameObject.SetActive(true);
        profileOneInput.Select();
        profileOneInput.ActivateInputField();
        profileOneName.SetText("Enter Name");

    }

}
