using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void PlayerMeshRotation() {

        if (Input.GetKeyDown(KeyCode.W)) {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = targetRotation;

        }

        if (Input.GetKeyDown(KeyCode.A)) {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = targetRotation;
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            Quaternion targetRotation = Quaternion.LookRotation(-Vector3.forward);
            transform.rotation = targetRotation;
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = targetRotation;
        }

    }
    

}

