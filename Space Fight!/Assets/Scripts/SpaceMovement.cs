using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class SpaceMovement : MonoBehaviour
{




    public Boundary boundary;

    public float speed = 10;
    public float rotate = 5;
    //private Rigidbody ship;

    // Use this for initialization
    void Awake()
    {
        //ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var move = speed * Time.deltaTime;
        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.forward * ver * move);
        transform.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * move * ver);
        transform.GetComponent<Rigidbody>().AddRelativeTorque(0f,hor*rotate, 0f);
        //changed movement to be more force related. Go Physics!
        //ship.AddRelativeForce(0f, 0f, ver*move);
        //ship.AddRelativeTorque(0f, hor*rotate, 0f);

        //transform.RotateAround(transform.position, Vector3.up, hor * rotate);

        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
        );

    }
}
