using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Profiling;
using UnityEngine.UI;


public class LevelSelectUI : MonoBehaviour
{
    public ProfileNameData profileName;
    public SaveLoad handleSaveData;
    public LevelSelect levelSelect;
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;
    public GameObject levelFour;
    public GameObject levelFive;


    public List<GameObject> summerLevels;
    void Start()
    {
        summerLevels = new List<GameObject> {
            levelOne,
            levelTwo,
            levelThree,
            levelFour,
            levelFive
        };
        SaveData profileData = handleSaveData.LoadProfileSaveData();
        int levelCounnter = profileData["Summer"].Count;
        int iterationCount = 0;

        foreach (GameObject level in summerLevels) {
            if ( levelCounnter == 0) {
                UnlockedLevel(level, 1);
                break;
            } else if (iterationCount >= levelCounnter) {
                    LockedLevel(level);
                } else {
                    int levelID = level.GetComponent<LevelSelect>().levelID;
                    UnlockedLevel(level, levelID);
                }
                iterationCount++;
        }      
    }


    public void UnlockedLevel(GameObject levelUI, int levelID) {
        Image lockImage = levelUI.transform.Find("Lock")?.GetComponent<Image>();
        TextMeshProUGUI levelNumber = levelUI.transform.Find("LevelNumber")?.GetComponent<TextMeshProUGUI>();
        levelNumber.text = $"#{levelID.ToString()}";
        lockImage.enabled = false;
        Debug.Log($"{levelID}");

    }

    public void LockedLevel(GameObject levelUI) {
        Image backgroundImg = levelUI.transform.Find("BackGround")?.GetComponent<Image>();
        backgroundImg.color = new Color(0.2196078f, 0.2196078f, 0.2196078f, 1f);
        Button selectButton = levelUI.transform.Find("SelectButton")?.GetComponent<Button>();
        selectButton.gameObject.SetActive(false);
        Image numImg = levelUI.transform.Find("NumImage")?.GetComponent<Image>();
        numImg.color = new Color(0.2196078f, 0.2196078f, 0.2196078f, 1f);
        Image lockImage = levelUI.transform.Find("Lock")?.GetComponent<Image>();
        lockImage.color = Color.white;


    }

    public void DisplayLevels() { 
    
    
    }

}
