using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    MyGrid map;
    Player player;
    private float playerZ; // Store the player's Z-axis position
    private int lastGeneratedZ = 0; // Keep track of last map generation point

    // Start is called before the first frame update
    void Start()
    {
        map = new MyGrid(20, 16, 3);
        player = new Player();
        playerZ = player.GetPlayerZPosition(); // Initial player Z position
        lastGeneratedZ = Mathf.FloorToInt(playerZ); // Initialize the last generated point
    }

    void Update()
    {
        // Continuously monitor player position
        float currentZ = player.GetPlayerZPosition();

        // Check if player has moved 10 tiles ahead
        if (currentZ - lastGeneratedZ >= 16f) {
            Debug.Log(currentZ);
            // Update the last generated Z point
            lastGeneratedZ = Mathf.FloorToInt(currentZ);

            // Add offset and generate more map
            map.SetOffset(20); // Increase offset by 20
            map.GenerateMap();  // Generate new chunks
        }
    }
}
