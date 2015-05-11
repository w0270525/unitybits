/*Rigidbody.AddForce(new Vector3(0,0,force)); //sends the object off by the force.

Rigidbody.AddForce(new Vector3(0,0,force), ForceMode.Impulse ); //more 'explosive' type of adding force.

Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
RaycastHit hit;

//allows for clicking to set the spin and direction based on click position.
If(Physics.Raycast(ray, out hit, 100))
	Rigidbody.AddForceAtPosition(transform.position - hit.point)* force,hit.point, ForceMode.Impulse );
*/

//New 'ExplosionScript'
using UnityEngine;
using System.Collections;
public class ExplosionScript : MonoBehaviour
{
	public float force;

	void Update(){
		
		if ((Input.GetButtonDown("Left")))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	RaycastHit hit;
	
	//allows for clicking to set the spin and direction based on click position.
		    if (Physics.Raycast(ray, out hit, 100))
		    {
		        //the 'hit.point' is where the force is coming from, effecting anything in the radius.
		        //GetComponent<Rigidbody>().AddExplosion(force, hit.point, 5, 0, ForceMode.Impulse);

		        //the zero in the last line can be changed to '1' to pop the item up in the air by default. 

		    }
		}
	
	}

}