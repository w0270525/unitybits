using UnityEngine;
using System.Collections;

public class BulletLife : MonoBehaviour
{

    public float bulletSpeed = 10f;//rate bullet travels
    public float lifeTime = 2.0f;//amount of time bullet will stay active
    private float startTime; //time bullet was started.
    private float checkTime;//time to check against the start time.

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
           
        }
        else
        {
            if (startTime == 0f)
            {
                startTime = Time.time;
            }
            else
            {
                checkTime = Time.time - startTime;
                if (checkTime >= lifeTime)
                {
                    startTime = 0f;
                    gameObject.SetActive(false);

                }
                gameObject.GetComponent<Rigidbody>().velocity=gameObject.transform.rotation * Vector3.forward*bulletSpeed;


            }
        }


    }


    /// <summary>
    /// handles the bullets hitting the enemy
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //ignore collision with player

        }
        else if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
            other.SendMessage("ApplyDamage", FindObjectOfType<Player>().damage);
        }
        else if (other.tag == "Bounds")
        {
            gameObject.SetActive(false);
        }
    }
}
