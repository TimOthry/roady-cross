using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos, playerOrigPos, playerTargerPos;
    private float timeToMove = 0.1f;
    private float dist = 1.6f; // Adjust this to match your grid size
    private LayerMask obstacleLayer; // Layer for obstacles

    void Update() {
        // Prevents multiple coroutines to occur at the same time
        if(isMoving) {
            return;
        }
        // Check for key releases and trigger movement
        if (Input.GetKeyUp(KeyCode.W)) {
            if (CanMove(Vector3.forward)) {
                StartCoroutine(MovePlayer(new Vector3(0, 0, dist)));
            }
        }
        else if (Input.GetKeyUp(KeyCode.S)) {
            if (CanMove(Vector3.back)) {
                StartCoroutine(MovePlayer(new Vector3(0, 0, -dist)));
            }
        }
        else if (Input.GetKeyUp(KeyCode.A)) {
            if (CanMove(Vector3.left)) {
                StartCoroutine(MovePlayer(new Vector3(-dist, 0, 0)));
            }
        }
        else if (Input.GetKeyUp(KeyCode.D)) {
            if (CanMove(Vector3.right)) {
                StartCoroutine(MovePlayer(new Vector3(dist, 0, 0)));
            }
        }
    }

    private bool CanMove(Vector3 direction) {
        // Perform a raycast in the desired direction to detect obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, dist, obstacleLayer)) {
            // If the raycast hits something, the player can't move
            Debug.Log("Obstacle in the way: " + hit.collider.name);
            return false;
        }
        // No obstacle detected, allow movement
        return true;
    }
    
    private IEnumerator MovePlayer(Vector3 direction) {
        isMoving = true;

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;
        playerOrigPos = transform.Find("default").position;
        playerTargerPos = playerOrigPos + new Vector3(0 , 0.5f, 0) + direction;

        // Allows coroutine to run in the next frame
        while(elapsedTime < timeToMove) {
            transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime / timeToMove);
            transform.Find("default").position = Vector3.Lerp(playerOrigPos, playerTargerPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        transform.Find("default").position = playerTargerPos;
        
        isMoving = false;
    }
}
