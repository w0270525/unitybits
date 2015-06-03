using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

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

    public int scoreValue;

    private bool isAlive = true;

    public int Health;
    protected GameObject[] PointList;
    protected GameObject scoreKeeper;

    protected Transform playerTransform;
    protected float elapsedTime;
    protected Vector3 destPos;
    protected GameObject objPlayer;
    public Object Explosion;

    //Turret if applicable.
    public Transform turret { get; set; }
    public Transform bulletSpawnPoint { get; set; }

    // Use this for initialization
    void Start()
    {
        currentState = FSMState.Patrol;

        scoreKeeper = GameObject.FindGameObjectWithTag("GameManager");

        elapsedTime = 0.0f;

        //setting list with waypoints.
        PointList = GameObject.FindGameObjectsWithTag("WayPoint");


        //random destination
        FindNextPoint();

        //find the player

        try
        {
            objPlayer = GameObject.FindGameObjectWithTag("Player");


            playerTransform = objPlayer.transform;
        }
        catch (System.Exception)
        {

            print("player missing.");
        }

        if (!playerTransform)
            print("Player doesn't exist.. Please add one " +
            "with Tag named 'Player'");



        //Unity 4.x Game AI Programming had a couple lines to get the turret transform and bullet spawn point.
        try
        {
           // turret = gameObject.transform.GetChild(0).transform;
           // bulletSpawnPoint = turret.GetChild(0).transform;


        }
        catch (System.Exception )
        {

          
        }


    }

     public void FindNextPoint()
    {

        int rndIndex = Random.Range(0, PointList.Length);
        float rndRadius = 10.0f;
        Vector3 rndPosition = Vector3.zero;
        destPos = PointList[rndIndex].transform.position + rndPosition;

        //check range to decide the random point
        if (IsInCurretnRange(destPos))
        {
            rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), -0.2f, Random.Range(-rndRadius, rndRadius));
            destPos = PointList[rndIndex].transform.position + rndPosition;

        }
    }

    /// <summary>
    /// returns whether the point is in the valid range.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool IsInCurretnRange(Vector3 pos)
    {
        float xPos = Mathf.Abs(pos.x - transform.position.x);
        float zPos = Mathf.Abs(pos.z - transform.position.z);

        if (xPos <= 50 && zPos <= 50)
            return true;

        return false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (currentState)
        {
            case FSMState.Patrol:
                UpdatePatrolState();
                break;
            case FSMState.Chase:
                UpdateChaseState();
                break;
            case FSMState.Attack:
                UpdateAttackState();
                break;
            case FSMState.Dead:
                UpdateDeadState();
                break;

        }

        elapsedTime += Time.deltaTime;

        if (Health <= 0)
            currentState = FSMState.Dead;


    }

    private void UpdateDeadState()
    {
        if (isAlive)
        {
            isAlive = false;
            Explode();
        }
    }

    /// <summary>
    /// causes explosion effect and gets rid of object
    /// </summary>
    private void Explode()
    {
        scoreKeeper.SendMessage("UpdateScore", scoreValue);


        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
    }

    

    public virtual void UpdateAttackState()
    {
        //Set the target postion to the player position
        destPos = playerTransform.position;

        //Check the distance
        float dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist >= 200.0f && dist < 300.0f)
        {
            //rotate toward target point(player)
            Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                Time.deltaTime * currentRotationSpeed);
            //Go forward
            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

            currentState = FSMState.Attack;
        }
        //transition to patrol if the player is too far away. 
        else if (dist >= 5.0f)
        {
            currentState = FSMState.Patrol;

        }
        /* //unused
        //always turn the turret towards the player
        Quaternion turretRotation =
            Quaternion.LookRotation(destPos - turret.position);

        turret.rotation =
            Quaternion.Slerp(turret.rotation, turretRotation, Time.deltaTime * currentRotationSpeed);
           */

        //shoot at player with bullets/projectiles
        //ShootBullet();
     

    }

    public void ShootBullet()
    {
        //Instantiate(Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        elapsedTime = 0.0f;
    }

    public virtual void UpdateChaseState()
    {
        //Set the target position as the player position
        destPos = playerTransform.position;


        //check distance with player. 
        //when distance is near, transition to attack state
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= 200.0f)
        {
            currentState = FSMState.Attack;

        }
        else if (distance >= 300.0f) //too far away, go back to patrol
        {
            currentState = FSMState.Patrol;
        }

        //Go forward
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
    }

    public virtual void UpdatePatrolState()
    {
        float dist = Vector3.Distance(transform.position, playerTransform.position);
        //Find another random patrol point from the list if point is reached
        if (Vector3.Distance(transform.position, destPos) <= 10.0f)
        {
            FindNextPoint();
        }

        //Check the distance from the player
        //when distance is near, transition to the chase state.
        else if (dist <= 300.0f)
        {
            currentState = FSMState.Chase;
        }

        //rotate to target point
        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * currentRotationSpeed);


        //Go forward
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);

    }

    void OnTriggerEnter(Collider other)
    {
        //may need some re jiggering to get this to work correctly with player lasers, possible damage multiplier.
        //reduce health
        if (other.tag == "Player")

        {
            objPlayer.SendMessage("ApplyDamage", 20);

            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void ApplyDamage(object value)
    {
        var val = (int) value;
        Health -= val;
    }
}
