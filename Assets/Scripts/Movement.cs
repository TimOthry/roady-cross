using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.1f;

    void Update() {
        // Prevents multiple coroutines to occur at the same time
        if(isMoving) {
            return;
        }
        // When a key is released the player moves by one tile
        if (Input.GetKeyUp(KeyCode.W)) {
                StartCoroutine(MovePlayer(new Vector3(0, 0, 1.6f)));
            }
        else if (Input.GetKeyUp(KeyCode.S)) {
                StartCoroutine(MovePlayer(new Vector3(0, 0, -1.6f)));
            }
        else if (Input.GetKeyUp(KeyCode.A)) {
                StartCoroutine(MovePlayer(new Vector3(-1.6f, 0, 0)));
            }
        else if (Input.GetKeyUp(KeyCode.D)) {
                StartCoroutine(MovePlayer(new Vector3(1.6f, 0, 0)));
            }
    }
    
    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        // Allows coroutine to run in the next frame
        while(elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        
        isMoving = false;
    }
}
