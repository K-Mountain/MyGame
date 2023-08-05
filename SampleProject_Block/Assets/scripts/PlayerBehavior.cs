using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody Rig;
    public float speed = 50.0f; //Playerの動く速度
    // Start is called before the first frame update
    void Start()
    {
        Rig = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = Vector3.zero;

        float Width = 6.5f;

        if (!BallBehavior.BallFinish)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Rig.transform.position.x>= Width*-1)
                {
                    force = new Vector3(speed * -1, 0, 0);
                }

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Rig.transform.position.x <= Width)
                {
                    force = new Vector3(speed * 1, 0, 0);
                }
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Rig.transform.position.z <= Width)
                {
                    force = new Vector3(0, 0, speed * 1);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (Rig.transform.position.z >= Width*-1)
                {
                    force = new Vector3(0, 0, speed * -1);
                }
            }

            Rig.MovePosition(Rig.position + force * Time.deltaTime);

        }

    }

}
