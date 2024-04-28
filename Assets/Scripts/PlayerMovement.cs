using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float distance = 1u;
    private HUD hudDisplay;
    private PlayerRotation spinPlayer;
    [SerializeField] public int movesLeft;
    private int startingSteps;
    private int stepsTaken;
    private bool winState;
    public bool keyCollected;
    public int collectedItems;
    public AudioSource winSFX;
    public AudioSource movementSFX;
    public Animator openGate;

    private void Start() {

        startingSteps = movesLeft;
        stepsTaken = 0;
        collectedItems = 0;
        keyCollected = false;
        hudDisplay = FindObjectOfType<HUD>();
        spinPlayer = FindObjectOfType<PlayerRotation>();
        hudDisplay.DisableHUD();
        hudDisplay.collectedFlowers.SetText(collectedItems.ToString() + " / 7");

    }

    // Update is called once per frame
    void Update() {
        if (winState == true) {
            GameWon();
            return;
        }

        if (movesLeft >= 1) {
            PlayerGridMovement();
        } else {
            GameOver();
        }

    }


    private void PlayerGridMovement() {

        if (Input.GetKeyDown(KeyCode.W)) {
            if (DetectTile(Vector3.forward)) {
                Movement(Vector3.forward);
                UpdateSteps();
                stepsTaken++;

            }
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            if (DetectTile(Vector3.left)) {
                Movement(Vector3.left);
                UpdateSteps(); 
                stepsTaken++;

            }
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            if (DetectTile(-Vector3.forward)) {
                Movement(-Vector3.forward);
                UpdateSteps();
                stepsTaken++;

            }
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            if (DetectTile(Vector3.right)) {
                Movement(Vector3.right);
                UpdateSteps();
                stepsTaken++;

            }
        }


    }

    private void Movement(Vector3 direction) {

        transform.Translate(direction * distance);
        spinPlayer.PlayerMeshRotation();
        movementSFX.Play();

    }

    private bool DetectTile(Vector3 direction) {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, direction);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.CompareTag("Tile")) {
                return true;
            } else if (hit.collider.CompareTag("WinTile")) {
                winSFX.Play();
                winState = true;
                return true;
            }
        }

        return false;

    }


    private void GameOver() {
        hudDisplay.gameOverText.gameObject.SetActive(true);
        hudDisplay.lostResetButton.gameObject.SetActive(true);
        hudDisplay.mainMenuButton.gameObject.SetActive(true);
    }

    private void GameWon() {
        hudDisplay.gameWonText.gameObject.SetActive(true);
        hudDisplay.wonNextButton.gameObject.SetActive(true);
        hudDisplay.wonResetButton.gameObject.SetActive(true);
        hudDisplay.mainMenuButton.gameObject.SetActive(true);
        hudDisplay.stepsTakenText.SetText("Total Steps Taken: " + stepsTaken.ToString());
    }


    private void UpdateSteps() {

        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (Collider collider in colliders) {
            if (collider.CompareTag("Grass+1")){
                movesLeft = startingSteps;
                collectedItems++;
                hudDisplay.collectedFlowers.SetText(collectedItems.ToString() + " / 7");
                hudDisplay.totalStepsLeft.SetText("Steps Left: " + movesLeft.ToString());
                return;
            } else if (collider.CompareTag("Tile")) {
                movesLeft--;
                hudDisplay.totalStepsLeft.SetText("Steps Left: " + movesLeft.ToString());
            }
        }
    }
}
