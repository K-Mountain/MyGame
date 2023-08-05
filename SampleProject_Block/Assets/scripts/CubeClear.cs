using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerSphere")
        {
            ScoreCounter.score += 10;
            Debug.Log("score:" + ScoreCounter.score);
            Destroy(this.gameObject);
        }
    }
}
