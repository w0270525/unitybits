using UnityEngine;
using System.Collections;
public class MassExplosionScript : MonoBehaviour
{
    public float force;
    public float radius;

    void Update()
    {

        if ((Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //allows for clicking to set the spin and direction based on click position.
            if (Physics.Raycast(ray, out hit, 100)){
                Collider[] colliders= Physics.OverlapSphere(hit.point, radius);
                
                foreach (Collider c in colliders)
                {
                    if(c.rigidbody==null) continue;
                    
                    //example psuedo code to make a box blow up into small parts.
                    if(c.gameObject.name=="box"){
                        //delete object
                        //instantiate broken model of box
                        //explode pieces!
                    }
                    
                    c.rigidbody.AddExplosionForce(force, hit.point, radius, 1, ForceMode.Impulse);
                }

            }
        }

    }
    
    void Start(){
        //this calls the Detonate() method after 3 seconds. ie: grenades.
        Invoke ("Detonate", 3);
    }

    void Detonate(){
        //explosion here
    }
}