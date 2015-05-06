using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour
{
    private LineRenderer line;
    public float flicker = 0.1f;
    private CursorLockMode wantedMode=CursorLockMode.Confined;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;

        //locks the cursor 
        Cursor.lockState = wantedMode;

        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //failsafe to avoid errors. ends coroutine before starting again. 
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }
    }


    //co-routine 
    IEnumerator FireLaser()
    {
        float timestamp = Time.time + flicker;
        line.enabled = true;
        while (Input.GetButton("Fire1"))
        {
            //autocorrected as the example is deprecated. was line.renderer.material....
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
            //The position
            
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;


            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hit, 100))
            {
                //the line will stop when touching collider
                line.SetPosition(1, hit.point);
                if (hit.rigidbody)
                {
                    //allows for 
                    hit.rigidbody.AddForceAtPosition(transform.forward * 5, hit.point);

                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        hit.transform.SendMessage("ApplyDamage", 100, SendMessageOptions.DontRequireReceiver);
                    }
                    //laser shader/line render try particles/verticallit blended
                }
            }
            else
            {
                //the point the line goes to 100 positions forward.

                line.SetPosition(1, ray.GetPoint(100));
            }


            if (Time.time >= timestamp)
            {
                line.enabled = !line.enabled;
                timestamp = Time.time + flicker;
            }



            yield return null;
        }

        line.enabled = false;

    }
}
