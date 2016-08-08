using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Controller2d))]
public class Player : MonoBehaviour {

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    float gravity = -20;
    float jumpVelocity;

    Vector3 velocity;
    float velocityXSmoothing;

    Controller2d playercontroller;

	// Use this for initialization
	void Start () {
        playercontroller = GetComponent<Controller2d>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        playercontroller.Move(velocity * Time.deltaTime);
	}
}
