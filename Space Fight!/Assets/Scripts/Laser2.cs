using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class Laser2 : MonoBehaviour
{

    private LineRenderer line;
    public float flickerDelay = 0.1f;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");

        }
    }

    IEnumerator FireLaser()
    {
        Debug.Log("coroutine started");

        float timestamp = Time.time + flickerDelay;
        line.enabled = true;
        //LaserLight.enabled = true;
        //LaserAudio.Play();

        while (Input.GetButton("Fire1"))
        {
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            line.SetPosition(0, ray.origin);
            line.SetPosition(1, ray.GetPoint(1000));

            if (Physics.Raycast(ray, out hit, 1000))
            {
                line.SetPosition(1, hit.point);
                if (hit.rigidbody)
                {
                    if (hit.transform.gameObject.tag == "Enemy")
                    {
                        hit.transform.SendMessage("ApplyDamage", 100, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            if (Time.time >= timestamp)
            {
                line.enabled = !line.enabled;
                timestamp = Time.time + flickerDelay;
            }

            yield return null;
        }
        line.enabled = false;
        //LaserLight.enabled = false;
        //LaserAudio.Stop();
        Debug.Log("coroutine ended");
    }
}