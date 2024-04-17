using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    public GameObject childObject;

    private void OnTriggerEnter(Collider other) {
       if (other.CompareTag("Player")) {
            IsChildActive();
        }
    }
    private IEnumerator DestroyChild() {
        float delayTime = 3f;
        yield return new WaitForSeconds(delayTime);
        childObject.SetActive(false);
    }

    private void IsChildActive() {
        if (childObject.activeSelf) {
            StartCoroutine(DestroyChild());
        }
    }
}
