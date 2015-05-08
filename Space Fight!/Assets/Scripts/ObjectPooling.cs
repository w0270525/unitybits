using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour {
	//this is called BulletFireScript in the tutorial
	//creating all objects up front and just reusing those objects. 
    //this example is with bullets but you could pool enemies, bullets, spaceships, cars.


	public float fireTime = 0.05f;
	public GameObject bullet;
	public int pooledAmount = 20;
	private List<GameObject> bullets;

	void Start()
	{
		bullets = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++)
		{
			var obj = (GameObject) Instantiate(bullet);
			obj.SetActive(false);
			bullets.Add(obj);
		}
		InvokeRepeating("Fire", fireTime, fireTime);
	}

	void Fire()
	{
		for (int i = 0; i < bullets.Count; i++) 
		{
			if (!bullets[i].activeInHierarchy)
			{
				bullets[i].transform.position = transform.position;
				bullets[i].transform.rotation = transform.rotation;
				bullets[i].SetActive(true);
				break;
			}
		}
	}
	



	// Update is called once per frame
	void Update () {
	
	}
}
