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
        gridArray = new int[height, width];
        this.GenerateMap();
    }

    public int GetHeight() => height;
    public int GetWidth() => width;

    public void GenerateMap() {
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
                }
            }
            if (chunk[z] == 2) {
                    z++;
            }
        }
    }

    public int[] Generate15Chunk() {
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

    // NOTE = The game has 14 wide visible map

    // Function for creating green bit
    // Function for creating road
    // Function for creating river
    // Function for creating trains

    // NOTE: Lilypads, logs, trains, cars, the chicken will be instantiated some where else

    // if log make the velocity of the chicken the same
}
