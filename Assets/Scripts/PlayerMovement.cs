using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float distance = 1u;


    // Update is called once per frame
    void Update()
    {

            PlayerGridMovement();
    }

    private void Movement(Vector3 direction) {

        transform.Translate(direction * distance);

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Tile")) {
            Debug.Log("True");
        } else {
            Debug.Log("False");
        }
    }

    private void PlayerGridMovement() {

        if (Input.GetKeyDown(KeyCode.W)) {
            if (DetectTile(Vector3.forward)) {
                Movement(Vector3.forward);
            }
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            if (DetectTile(Vector3.left)) {
                Movement(Vector3.left);
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            if (DetectTile(-Vector3.forward)) {
                Movement(-Vector3.forward);
            }
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            if (DetectTile(Vector3.right)) {
                Movement(Vector3.right);
            }
        }


    }

    private bool DetectTile(Vector3 direction) {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.CompareTag("Tile")) {
                return true;
            }
        }
        return false;
       
    }



}
