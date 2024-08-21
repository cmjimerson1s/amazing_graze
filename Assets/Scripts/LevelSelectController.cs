using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUI : MonoBehaviour
{
    public ProfileNameData profileName;
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
    }

    public void DisplayLevels() { 
    
    
    }

}
