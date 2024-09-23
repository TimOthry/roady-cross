using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    public float minSpawnInterval = 1f;    // Minimum time between spawns
    public float maxSpawnInterval = 3f;    // Maximum time between spawns
    public float spawnZOffset = 0f;        // Adjust Z position if necessary
    public Transform spawnPoint;           // Where the object will be spawned

    // Start is called before the first frame update
    void Start()
    {
        //  StartCoroutine(SpawnTrain());
    }

    // private IEnumerator SpawnTrain() {
        
    // }
}
