using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid
{
    // Instantiate basic variables
    private int width;
    private int height;
    private int[,] gridArray;
    private GameObject prefab;
    
    // Constructor
    public MyGrid(int width, int height) {
        this.width = width;
        this.height = height;
        gridArray = new int[width, height];
        this.GenerateMap();
    }

    public int GetWidth() => width;
    public int GetHeight() => height;

    public void GenerateMap() {
        for(int x = 0; x < this.GetWidth(); x++) {
            for (int y = 0; y < this.GetHeight(); y++) {
                prefab = Resources.Load<GameObject>("Prefabs/light-grass");
                Object.Instantiate(prefab, new Vector3(x * 1.6f, 0, y * 1.6f), Quaternion.identity);
            }
        }
    }

    // NOTE = The game has 14 wide visible map

    // Function for creating green bit
    // Function for creating road
    // Function for creating river
    // Function for creating trains

    // NOTE: Lilypads, logs, trains, cars, the chicken will be instantiated some where else
}
