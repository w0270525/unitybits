using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private Transform t;
    Rigidbody2D r;
    public float speed = 50;
	// Use this for initialization
	void Start () {
        r = GetComponent<Rigidbody2D>();
  
	}
	
	// Update is called once per frame
	void Update () {

        var move = speed * Time.deltaTime;
        var ver = Input.GetAxis("Vertical");
        var hor = Input.GetAxis("Horizontal");
        r.AddForce(Vector3.right * hor * move);
    }
}
