using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid
{
    // Instantiate basic variables
    private int height;
    private int width;
    private int[,] gridArray;
    private GameObject prefab;
    
    // Constructor
    public MyGrid(int height, int width) {
        this.height = height;
        this.width = width;
        this.GenerateMap();
    }

    public int GetHeight() => height;
    public int GetWidth() => width;

    private void GenerateMap() {
        int[] chunk = Generate15Chunk();
        string[] row = {"light-grass", "light-road", "rail", "light-river"};
        for(int z = 0; z < this.GetHeight(); z++) {
            for (int x = 0; x < this.GetWidth(); x++) {
                prefab = Resources.Load<GameObject>($"Prefabs/{row[chunk[z] - 1]}");
                if (chunk[z] == 2) {
                    Object.Instantiate(prefab, new Vector3(x * 1.6f + 0.8f, 0, z * 1.6f + 0.8f), Quaternion.identity);
                    x++;
                } else {
                    Object.Instantiate(prefab, new Vector3(x * 1.6f, 0, z * 1.6f), Quaternion.identity);
                    placeObstacle(chunk[z],x, z);
                }
            }
            if (chunk[z] == 2) {
                    z++;
            }
        }
    }

    // Generates 15 number string where numbers 1234 represent a terrain
    private int[] Generate15Chunk() {
        System.Random random = new System.Random();
        int length = GetHeight(), i = 0;
        int[] numberArray = new int[length];

        while (i < length) {
            int digit = random.Next(1, 5);

            if (digit == 2) {
                if (i < length - 1) {
                    numberArray[i] = 2;
                    numberArray[i + 1] = 2;
                    i += 2; 
                }
            } else if (digit == 4) {
                if (i < length - 1) {
                    numberArray[i] = 4;
                    numberArray[i + 1] = 4;
                    i += 2;
                }
            } else {
                numberArray[i] = digit;
                i++;
            }
        }
        return numberArray;
    }

    private void placeObstacle(int terrain, int x, int z) {
        if (terrain == 1) {
            System.Random random = new System.Random();
            float chance = random.Next(0, 100); 

            // 10% chance to place an obstacle
            if (chance < 5) {
                prefab = Resources.Load<GameObject>($"Prefabs/rock");
                Object.Instantiate(prefab, new Vector3(x * 1.6f, 0.2f, z * 1.6f), Quaternion.identity);
            } else if (chance >= 5 && chance < 15) {
                prefab = Resources.Load<GameObject>($"Prefabs/small-tree");
                Object.Instantiate(prefab, new Vector3(x * 1.6f, 1.1f, z * 1.6f), Quaternion.identity);
            } else if (chance >= 15 && chance < 25) {
                prefab = Resources.Load<GameObject>($"Prefabs/med-tree");
                Object.Instantiate(prefab, new Vector3(x * 1.6f, 1.1f, z * 1.6f), Quaternion.identity);
            } else if (chance >= 25 && chance < 35) {
                prefab = Resources.Load<GameObject>($"Prefabs/big-tree");
                Object.Instantiate(prefab, new Vector3(x * 1.6f, 1.1f, z * 1.6f), Quaternion.identity);
            }
        }
    }

    // Add collision logic
    // Add cars, trains and logs
    // Add death and point system
    // if log make the velocity of the chicken the same
    // done with the basic game

    // Implement better camera
    // Traffic light
    // Lilypads
    // Sound effects
}
