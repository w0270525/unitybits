using UnityEngine;
using System.Collections;

public class SimpleFSM : MonoBehaviour
{


	public enum FSMState
	{
		None,
		Patrol,
		Chase,
		Attack,
		Dead,
	}

	//Current state the NPC is reaching
	public FSMState currentState;

	//Speed of the npc
	public float currentSpeed = 150.0f;


	//Rotation of the npc
	public float currentRotationSpeed = 2.0f;

	//bullet/laser
	public GameObject Bullet;

	private bool isAlive = true;

	public int Health { get; set; }
	protected GameObject[] pointList;


	// Use this for initialization
	void Start()
	{
		currentState = FSMState.Patrol;

		Health = 100;

		//setting list with waypoints.
		pointList = GameObject.FindGameObjectsWithTag("WanderPoint");

		
		//random destination
		FindNextPoint();





	}

	private void FindNextPoint()
	{
		throw new System.NotImplementedException();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
