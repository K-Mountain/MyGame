using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Rigidbody rig;
    private Vector3 _velocity;
    private Vector3 _position;
    private float _positionY;
    [SerializeField] Vector3 forceX;
    [SerializeField] Vector3 forceY;
    [SerializeField] Vector3 forceZ;
    public static bool BallFinish;
    public static bool BallOver;

    void Start()
    {
        rig = this.GetComponent<Rigidbody>();
        forceX = new Vector3(1f, 0, 0);
        forceY = new Vector3(0, 1f, 0);
        forceZ = new Vector3(0, 0, 1f);
        _velocity = rig.velocity;
        _position = this.gameObject.transform.position;
        _positionY = _position.y;
        BallFinish = false;
        BallOver = false;

        float force1 = Random.value * 2 + 2;
        float force2 = Random.value * 2 + 3;
        float force3 = Random.value * 2 + 1;
        Vector3 force = new Vector3(force1, force2 * -1, force3);
        rig.AddForce(force, ForceMode.VelocityChange);
    }

    private void Update()
    {
        if(BallFinish)
        {
            BallFreeze();
        }
    }

    private void BallFreeze()
    {
        rig.constraints = RigidbodyConstraints.FreezePosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        float bounce = 1.05f; //反発係数
        Vector3 otherPosition = other.gameObject.transform.position;
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player発見");
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y * -1, rig.velocity.z) *bounce;
        }

        if(other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Cube発見");
            if(_positionY<6 & _positionY>4)
            {
                float distanceX = Mathf.Abs(otherPosition.x - _position.x);
                float distanceZ = Mathf.Abs(otherPosition.z - _position.z);
                if (distanceX < distanceZ)
                {
                    rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, rig.velocity.z * -1) *bounce;
                    Debug.Log("z反射");
                }
                else
                {
                    rig.velocity = new Vector3(rig.velocity.x * -1, rig.velocity.y, rig.velocity.z) *bounce;
                    Debug.Log("x反射");
                }
            }
            else
            {
                rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y * -1, rig.velocity.z) *bounce;
                Debug.Log("y反射");
            }
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            BallFinish = true;
            BallOver = true;
            Debug.Log("Finish!");
        }
    }



}
