using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float CashTotal = 1400.0f;

    public float cash = 0.0f;

    private Transform ThisTransform=null;
	// Use this for initialization
	void Start ()
	{

	    MeshRenderer Capsule = GetComponentInChildren<MeshRenderer>();
	    Capsule.enabled = false;
	    ThisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float Cash
    {
        get { return cash; }

        set
        {
            cash = value;
            if (cash >= CashTotal)
                GameManager.Notifications.PostNotification(this, "CashCollected");
        }
    }
}
