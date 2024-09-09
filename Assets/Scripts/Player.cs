using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int currentWidth, currentHeight;
    private GameObject prefab;
    private GameObject playerObject;
    
    public Player() {
        currentWidth = 7;
        currentHeight = 0;
        prefab = Resources.Load<GameObject>("Prefabs/chicken");
        playerObject = Object.Instantiate(prefab, new Vector3(currentWidth * 1.6f, 0.3f, currentHeight * 1.6f), Quaternion.identity);
    }

    public int GetCurrentWidth() => currentWidth;
    public int GetCurrentHeight() => currentHeight;

    public void SetCurrentWidth() => currentWidth+=1;
    public void SetCurrentHeight() => currentHeight+=1;
}