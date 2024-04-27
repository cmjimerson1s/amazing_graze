using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockConroller : MonoBehaviour {

    public Animator openGate;
    public AudioSource keyCollected;
    public AudioSource gateOpenSFX;
    private PlayerMovement player;

    void Start() {
        player = FindObjectOfType<PlayerMovement>();

    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            player.keyCollected = true;
            gameObject.SetActive(false);
            keyCollected.Play();
            gateOpenSFX.Play(); 
            OpenFence();
        }
    }
    private void OpenFence() {
        GameObject[] fence;
        fence = GameObject.FindGameObjectsWithTag("Lock");
        openGate.Play("GateOpen", 0, 0.0f);
    }
}
