using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour
{
	[SerializeField]
	private float speed = 90f;

	[SerializeField] private float turnSpeed = 5f;
	[SerializeField] private float hoverForce = 65f;
	[SerializeField] private float hoverHeight = 3.5f;

	private float powerInput;
	private float turnInput;
	private Rigidbody carRigidBody;

	


	// Use this for initialization
	void Awake ()
	{
		//previous rigidbody shortcut is deprecated.
		carRigidBody = GetComponent<Rigidbody>();


	}
	
	// Update is called once per frame
	void Update ()
	{
		//don't do physics things in the update function. framerate dependant
		powerInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
	}

	void FixedUpdate()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		//use to check if within hover height
		if (Physics.Raycast(ray, out hit, hoverHeight))
		{
			float proportionalHeight = (hoverHeight - hit.distance)/hoverHeight;//represent the height
			//vector3.up is shorthand for (0,1,0)
			Vector3 appliedHoverForce = Vector3.up*proportionalHeight*hoverForce;

			//applies force
			carRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);

		}
		//adding force to move forward and backward.
		carRigidBody.AddRelativeForce(0f, 0f, powerInput*speed);

		//torques hovercar based on left and right turns
		carRigidBody.AddRelativeTorque(0f, turnInput*turnSpeed, 0f);

	}
}
