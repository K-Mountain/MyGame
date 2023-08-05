using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //CubeClearでCube消去時に10加算される
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
