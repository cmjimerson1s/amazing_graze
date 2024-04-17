using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    private HUD hudDisplay;
    private PlayerMovement player;

    private void Start() {

        hudDisplay = FindObjectOfType<HUD>();
        player = FindObjectOfType<PlayerMovement>();

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            player.collectedItems++;
            Debug.Log(player.collectedItems.ToString());
            gameObject.SetActive(false);
            CollectedItemUpdate();
        }
    }

    private void CollectedItemUpdate() {
        if (player.collectedItems == 1) {
            hudDisplay.oneCollected.gameObject.SetActive(true);
            hudDisplay.circle1.gameObject.SetActive(false);
        } else if (player.collectedItems == 2) {
            hudDisplay.twoCollected.gameObject.SetActive(true);
            hudDisplay.circle2.gameObject.SetActive(false);
        } else if (player.collectedItems == 3) {
            hudDisplay.threeCollected.gameObject.SetActive(true);
            hudDisplay.circle3.gameObject.SetActive(false);
        }
    }
}
