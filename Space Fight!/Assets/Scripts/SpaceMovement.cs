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
   
	// Use this for initialization
	void Start ()
	{
	 
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

		var move = speed * Time.deltaTime;
		var ver = Input.GetAxis("Vertical");
		var hor = Input.GetAxis("Horizontal");

		transform.Translate(Vector3.forward * ver * move);
		//transform.Translate(Vector3.right * hor * move); 
		transform.RotateAround(transform.position, Vector3.up, hor* rotate);
	   
        GetComponent<Rigidbody>().position = new Vector3
	    (
	        Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
	        0.0f,
	        Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
	    );
       
    }
}
