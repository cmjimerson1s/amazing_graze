using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "SaveDataInfo")]
public class SceneInfo : ScriptableObject {
     public Dictionary<string, Dictionary<int, Dictionary<string, int>>> saveDataInfo;
    public void Initialize(string season) {
        saveDataInfo = new Dictionary<string, Dictionary<int, Dictionary<string, int>>> {
            {season, new Dictionary<int, Dictionary<string, int>> {
                {1, new Dictionary<string, int> {
                    {"Steps", 1 }
                } }
            } }
        };
        //saveGame.SerializeJson(saveDataInfo);
    }
    
}
