using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelSelect : MonoBehaviour
{
    public SceneName sceneName;
    public int levelID;

    public void LoadLevel() {
        string scene = sceneName.ToString();
        SceneManager.LoadScene(scene);
    }

}
