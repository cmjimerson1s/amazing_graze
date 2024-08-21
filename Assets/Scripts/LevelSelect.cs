using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;


public class LevelSelect : MonoBehaviour
{
    public GameObject levelUI;
    public int levelID;

    public void Start() {
        LockedLevel();
    }
    public void UnlockedLevel() {
        Image lockImage = levelUI.transform.Find("Lock")?.GetComponent<Image>();
        TextMeshProUGUI levelText = transform.GetComponentInChildren<TextMeshProUGUI>();
        levelText.text = $"#{levelID.ToString()}";
        lockImage.enabled = false;

    }

    public void LockedLevel() {
        Image backgroundImg = levelUI.transform.Find("BackGround")?.GetComponent<Image>();
        backgroundImg.color = new Color(0.2196078f, 0.2196078f, 0.2196078f, 1f);
        Button selectButton = levelUI.transform.Find("SelectButton")?.GetComponent<Button>();
        selectButton.gameObject.SetActive(false); 
        Image numImg = levelUI.transform.Find("NumImage")?.GetComponent<Image>();
        numImg.color = new Color(0.2196078f, 0.2196078f, 0.2196078f, 1f);
        Image lockImage = levelUI.transform.Find("Lock")?.GetComponent<Image>();
        lockImage.color = Color.white;


    }

}
