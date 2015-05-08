using UnityEngine;
using System.Collections;

public class BulletFire : MonoBehaviour
{

    public float firetime = 0.0f;

	// Use this for initialization
	void Start ()
	{
	    InvokeRepeating("fire", firetime, firetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	
    }

    void Fire()
    {
        GameObject obj = NewObjectPoolerScript.current.GetPooledObject();
        if(obj==null)
        return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
