using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    public GameObject childObject;

    void Start()
    {
        childObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (childObject.activeSelf) {
            StartCoroutine(DestroyChild());
        }
     
    }

    private IEnumerator DestroyChild() {
        float delayTime = 1f;
        yield return new WaitForSeconds(delayTime);
        childObject.SetActive(false);
    }
}
