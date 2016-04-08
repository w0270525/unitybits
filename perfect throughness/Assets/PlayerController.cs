using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        var move = speed * Time.deltaTime;
        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");

        transform.GetComponent<Rigidbody2D>().AddForce(Vector3.right * hor * speed);
    }
}
