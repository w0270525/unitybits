using UnityEngine;
using System.Collections;

public class Powerup_Dollar : MonoBehaviour
{
    //setting the amount of cash for the powerup. 
    public float cashAmount = 100.0f;

    //the audio clip for this object.
    public AudioClip clip = null;

    //the audio source for used for sound playback.
    private AudioSource sfx = null;


	// Use this for initialization
	void Start () {

	    //find sound object in scene
	    GameObject soundObject = GameObject.FindGameObjectWithTag("sounds");

        //If no sound the exit.
	    if (soundObject == null) return;

	    sfx = soundObject.GetComponent<AudioSource>();

	}

    //Event triggered when colliding. unity api function
    void OnTriggerEnter(Collider other)
    {
        //Is colliding object a player? checks if thing colliding is a player or not.
        if (!other.CompareTag("player")) return;

        //plays sound if available.
        if (sfx)
        {
            sfx.PlayOneShot(clip, 1.0f);
        }

        //hide object so it can't be collected more than once
        gameObject.SetActive(false);

        //get the playercontroller and update the cash.
        PlayerController pc = other.gameObject.GetComponent<PlayerController>();

        //if there is a player character attached to the colliding object, update cash.
        if (pc) pc.Cash += cashAmount;

        //Post poserup collected notification so other objects can handle this event if necessary.
        GameManager.Notifications.PostNotification(this, "PowerupCollected");
    }
	

}
