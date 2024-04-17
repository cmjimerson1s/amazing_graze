using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI totalStepsLeft;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameWonText;
    public TextMeshProUGUI stepsTakenText;
    public GameObject lostResetButton;
    public GameObject wonResetButton;
    public GameObject wonNextButton;
    public GameObject oneCollected;
    public GameObject twoCollected;
    public GameObject threeCollected;
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game Reset");
    }

    public void DisableHUD() {
        gameOverText.gameObject.SetActive(false);
        lostResetButton.gameObject.SetActive(false);
        gameWonText.gameObject.SetActive(false);
        wonNextButton.gameObject.SetActive(false);
        wonResetButton.gameObject.SetActive(false);
        oneCollected.gameObject.SetActive(false);
        twoCollected.gameObject.SetActive(false);
        threeCollected.gameObject.SetActive(false);

    }

}
