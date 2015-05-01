using UnityEngine;
using System.Collections;

public class PingPongDistance : MonoBehaviour
{
    //Direction to move
    public Vector3 MoveDir = Vector3.zero;

    //Speed to move - units per second
    public float speed = 0.3f;

    //Distance to travel in world units (before inverting direction and turning back)
    public float travelDistance = 0.5f;

    //Cached Transform
    private Transform thisTransform = null;

    // Use this for initialization
    IEnumerator Start()
    {
        //Get cached transform
        thisTransform = transform;

        //Loop forever
        while (true)
        {
            //Invert direction
            MoveDir = MoveDir * -1;

            //Start movement
            yield return StartCoroutine(Travel());
        }
    }

    //Travel full distance in direction, from current position
    IEnumerator Travel()
    {
        //Distance travelled so far
        float distanceTravelled = 0;

        //Move
        while (distanceTravelled < travelDistance)
        {
            //Get new position based on speed and direction
            Vector3 distToTravel = MoveDir * speed * Time.deltaTime;

            //Update position
            thisTransform.position += distToTravel;

            //Update distance travelled so far
            distanceTravelled += distToTravel.magnitude;

            //Wait until next update
            yield return null;
        }
    }
}