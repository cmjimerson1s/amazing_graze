using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    private string filePath;
    public TMP_InputField profileOne;

    void Start() {
        filePath = Application.persistentDataPath;
        string[] files = System.IO.Directory.GetFiles(filePath);
        Debug.Log(files[0]);
        foreach (string file in files) {
            string fileName = Path.GetFileName(file);
            Debug.Log("File:" +  fileName);
        }
    }
}
