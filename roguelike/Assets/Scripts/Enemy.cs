﻿using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {

    public int playerDamage;

    private Animator animator;
    private Transform target;
    private bool skipMove;
    public AudioClip enemyAttack1;
    public AudioClip enemyAttack2;



    protected override void Start()
    {
        GameManager.instance.AddEnemyToList(this);
        

        //Get and store a reference to the attached Animator component.
        animator = GetComponent<Animator>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //Call the start function of our base class MovingObject.
        base.Start();
    }	
	// Update is called once per frame
	void Update () {
	
	}

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        if(skipMove)
        {
            skipMove = false;
            return;

        }

        base.AttemptMove<T>(xDir, yDir);

        skipMove = true;

    }

    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            yDir = target.position.y > transform.position.y ? 1 : -1;
        else
            xDir = target.position.x > transform.position.x ? 1 : -1;

        AttemptMove<Player>(xDir, yDir);


    }

    protected override void OnCantMove<T>(T component)
    {
        Player hitPlayer = component as Player;

        animator.SetTrigger("enemyAttack");
        SoundManager.instance.RandomizeSfx(enemyAttack1, enemyAttack2);

        hitPlayer.LoseFood(playerDamage);
    }
}
