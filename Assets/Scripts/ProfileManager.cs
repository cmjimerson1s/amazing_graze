using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using TMPro;
using static UnityEditor.FilePathAttribute;
using File = System.IO.File;
using Newtonsoft.Json;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour {
    private IDataService DataService = new JsonDataService();
    private string filePath;
    private bool EncryptionEnabled;
    public GameObject profileOne;
    public GameObject profileTwo;
    public GameObject profileThree;

    void Start() {
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

       if (profileNames.Count == 1) {
            DisplayProfileInformation(profileOne, profileNames[0]);
            profileTwo.GetComponentInChildren<TextMeshProUGUI>().text = "New Game";
            profileThree.GetComponentInChildren<TextMeshProUGUI>().text = "New Game";
       } else if (profileNames.Count == 2) {
            DisplayProfileInformation(profileOne, profileNames[0]);
            DisplayProfileInformation(profileTwo, profileNames[1]);
            profileThree.GetComponentInChildren<TextMeshProUGUI>().text = "New Game";
        } else if (profileNames.Count == 3) {
            DisplayProfileInformation(profileOne, profileNames[0]);
            DisplayProfileInformation(profileTwo, profileNames[1]);
            DisplayProfileInformation(profileThree, profileNames[2]);
        }

    }

    public void NewGame(GameObject profileUI) {
        string profile = "/user-profiles.json";
        filePath = Application.persistentDataPath + profile;
        if (File.Exists(filePath)) {
            List<string> profileNames = DataService.LoadData<List<string>>(profile, EncryptionEnabled);
            TMP_InputField profileNameInput = profileUI.GetComponentInChildren<TMP_InputField>();
            string profileName = profileNameInput.text;
            profileNames.Add(profileName);
            SaveProfile(profileNames);
        } else {
            Debug.Log("No file found");
            List<string> profileNames = new List<string>();
            TMP_InputField profileNameInput = profileUI.GetComponentInChildren<TMP_InputField>();
            string profileName = profileNameInput.text;
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


    public void NewGameButton(GameObject profileUI) {
        Button selectButton = profileUI.transform.Find("SelectButton")?.GetComponent<Button>();
        selectButton.gameObject.SetActive(false);
        TMP_InputField profileName = profileUI.GetComponentInChildren<TMP_InputField>();
        TextMeshProUGUI imageText = profileUI.GetComponentInChildren<TextMeshProUGUI>();
        imageText.text = "Enter Name";
        profileName.interactable = true;
        profileName.Select();
        profileName.ActivateInputField();

    }

    public void DisplayProfileInformation(GameObject profileUI, string profileName) {
        Button selectButton = profileUI.transform.Find("SelectButton")?.GetComponent<Button>();
        selectButton.gameObject.SetActive(false);
        Button doneButton = profileUI.transform.Find("DoneButton")?.GetComponent<Button>();
        doneButton.gameObject.SetActive(false);
        TextMeshProUGUI imageText = profileUI.GetComponentInChildren<TextMeshProUGUI>();
        imageText.text = $"{profileName}";
    }


}
