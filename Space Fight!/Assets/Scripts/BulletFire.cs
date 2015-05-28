using UnityEngine;
using System.Collections;

public class BulletFire : MonoBehaviour
{

    public float firetime = 0.3f;
    public float fireRate = 200f;
    public int damage = 50;
    public float bulletForce=50f;

    // Use this for initialization
    void Start ()
    {
       
    }
    
    // Update is called once per frame
    void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            Invoke("Fire", firetime);
        }
    
    }

    void Fire()
    {
        GameObject obj = NewObjectPoolerScript.current.GetPooledObject();
        if(obj==null)
        return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        obj.GetComponent<Rigidbody>().AddForce(Vector3.forward*fireRate);
    }
}
