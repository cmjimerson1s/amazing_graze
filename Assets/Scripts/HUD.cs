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
    public GameObject resetButton;



    void Update() { 
        
    }

    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game Reset");
    }
 
}
