using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistantData : MonoBehaviour
{
    public SceneInfo saveDict;
    public TestDataScript saveGame;

    public void LevelSaveData(string season, int level, int steps) {
        if (saveDict.saveDataInfo == null) {
            saveDict.Initialize(season);
        }
        AddNewLevelSteps(season, level, steps);
        PrintDictionary();

    }

    void AddNewLevelSteps(string mainKey, int newLevelKey, int newStepsValue) {
        if (saveDict.saveDataInfo.ContainsKey(mainKey)) {
            // Get the dictionary associated with the main key (e.g., "Summer")
            var levelDict = saveDict.saveDataInfo[mainKey];
            // Add the new Level with Steps
            levelDict[newLevelKey] = new Dictionary<string, int>
            {
                { "Steps", newStepsValue }
            };
        } else {
            // If the main key does not exist, add it with the new Level and Steps
            saveDict.saveDataInfo[mainKey] = new Dictionary<int, Dictionary<string, int>>
            {
            { newLevelKey, new Dictionary<string, int>
                {
                    { "Steps", newStepsValue }
                }
            }
        };

        }
    }

    public void PrintDictionary() {
        foreach (var mainEntry in saveDict.saveDataInfo) {
            Debug.Log(mainEntry.Key + ":");
            foreach (var levelEntry in mainEntry.Value) {
                Debug.Log("Level " + levelEntry.Key + ":");
                foreach (var stepsEntry in levelEntry.Value) {
                    Debug.Log("    " + stepsEntry.Key + ": " + stepsEntry.Value);
                }
            }
        }
    }
}
