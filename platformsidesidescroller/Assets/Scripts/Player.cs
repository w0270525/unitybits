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
    float jumpVelocity = 8;

    Vector3 velocity;
    float velocityXSmoothing;

    Controller2d playercontroller;

	// Use this for initialization
	void Start () {
        playercontroller = GetComponent<Controller2d>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        print("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
	}
	
	// Update is called once per frame
	void Update () {

        if (playercontroller.collisions.above || playercontroller.collisions.below)
        {
            velocity.y = 0;
        }


        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Joystick1Button0)||Input.GetKeyDown(KeyCode.Space) && playercontroller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (playercontroller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        playercontroller.Move(velocity * Time.deltaTime);
	}
}
