using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

    void Start() {
        
    }

    void Update() {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Destroy")) {
            Destroy(gameObject);
        }
    }
}
