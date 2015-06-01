using UnityEngine;
using System.Collections;

public class JetEnemy : SimpleFSM
{


    public override void UpdatePatrolState()
    {

        float dist = Vector3.Distance(transform.position, playerTransform.position);
        //Find another random patrol point from the list if point is reached
        if (Vector3.Distance(transform.position, destPos) <= 3.0f)
        {
            currentState = FSMState.Attack;

        }



        //rotate to target point
        Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * currentRotationSpeed);


        //Go forward
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
    }

    public override void UpdateAttackState()
    {
        //Set the target postion to the player position
        destPos = playerTransform.position;

        //Check the distance
        float dist = Vector3.Distance(transform.position, playerTransform.position);

        if (objPlayer.active)
        {
            //rotate toward target point(player)
            Quaternion targetRotation = Quaternion.LookRotation(destPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
                Time.deltaTime * currentRotationSpeed);

            //shoot at the player then find new patrol spot. 
            ShootBullet();

            currentState = FSMState.Patrol;

        }
        //transition to patrol if the player is too far away. 
        else
        {
            currentState = FSMState.Patrol;

        }



    }



}