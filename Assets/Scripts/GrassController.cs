using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrassController : MonoBehaviour {
    
    [SerializeField] int energyAmount;
    [SerializeField] private Animator numberSign;
    [SerializeField] GameObject meshChildObject;
    [SerializeField] GameObject textChildObject;

    public AudioSource grassSFX;

    private HUD hudDisplay;
    private PlayerMovement player;

    void Start()
    {
        hudDisplay = FindObjectOfType<HUD>();
        player = FindObjectOfType<PlayerMovement>();
        textChildObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CollectGrass();
        }
    }

    private void IsChildActive() {
        if (textChildObject.activeSelf) {
            numberSign.Play("NumberSign", 0, 0.0f);
            StartCoroutine(DestroyChild());
        }
    }
    private IEnumerator DestroyChild() {
        float delayTime = 1f;
        yield return new WaitForSeconds(delayTime);
        textChildObject.SetActive(false);
    }

    private void CollectGrass() {
        grassSFX.Play();
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        meshChildObject.SetActive(false);
        textChildObject.SetActive(true);
        IsChildActive();
    }

}
