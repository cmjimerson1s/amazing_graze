using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    public GameObject childObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (gameObject.activeSelf) {

        } else {
            childObject.SetActive(true);
        }

     
    }
}
