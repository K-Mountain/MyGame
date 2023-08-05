using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShadowBehavior : MonoBehaviour
{

    [SerializeField] GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("PlayerSphere");
        Vector3 targetPosition = target.transform.position;
        Vector3 thisPosition = this.gameObject.transform.position;
        float targetPositionX = targetPosition.x;
        float targetPositionZ = targetPosition.z;
        float thisPositionY = thisPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 thisPosition = this.gameObject.transform.position;
        Vector3 Position = new Vector3(targetPosition.x, thisPosition.y, targetPosition.z);
        this.gameObject.transform.position = Position;
    }
}
