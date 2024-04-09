using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        // Check if the entering collider belongs to object2
        if (other.CompareTag("Player")) {
            // Display the name of object1
            Debug.Log(transform.parent.gameObject.name);
        } 
    }
}
