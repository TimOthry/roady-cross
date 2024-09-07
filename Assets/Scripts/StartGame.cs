using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        MyGrid grid = new MyGrid(9, 20);
    }
}
