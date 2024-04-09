using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float distance;
    private bool canMove;


    // Update is called once per frame
    void Update()
    {

        if (canMove == true) {
            PlayerGridMovement();
        }
    }

    private void Movement(Vector3 direction) {
        
        transform.Translate(direction * distance * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Tile")) {
            canMove = true;
        } else {
            canMove = false;
            Debug.Log("False");
        }
    }

    private void PlayerGridMovement() {

        if (Input.GetKeyUp(KeyCode.W))
            Movement(Vector3.forward);

        if (Input.GetKeyUp(KeyCode.A))
            Movement(Vector3.left);

        if (Input.GetKeyUp(KeyCode.S))
            Movement(-Vector3.forward);

        if (Input.GetKeyUp(KeyCode.D))
            Movement(Vector3.right);

    }

}
