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
    public TextMeshProUGUI collectedFlowers;
    public GameObject lostResetButton;
    public GameObject wonResetButton;
    public GameObject wonNextButton;
    public GameObject mainMenuButton;
    

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game Reset");
    }

    public void MainMenu() {
        SceneManager.LoadSceneAsync(0);
    }

    public void DisableHUD() {
        gameOverText.gameObject.SetActive(false);
        lostResetButton.gameObject.SetActive(false);
        gameWonText.gameObject.SetActive(false);
        wonNextButton.gameObject.SetActive(false);
        wonResetButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

}
