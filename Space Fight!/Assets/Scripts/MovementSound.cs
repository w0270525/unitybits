using UnityEngine;
using System.Collections;

public class MovementSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource jetSound;

    private float jetPitch;
    private const float LowPitch = .1f;
    private const float HighPitch = 2.0f;
    
    private const float SpeedToRevs = .01f;

    private Vector3 myVelocity;
    private Rigidbody carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();


    }

    private void FixedUpdate()
    {
        //velocity comes in at a world space value
        myVelocity = carRigidbody.velocity;
        float forwardSpeed = transform.InverseTransformDirection(myVelocity).z;
        float engineRevs = Mathf.Abs(forwardSpeed)*SpeedToRevs;
        jetSound.pitch = Mathf.Clamp(engineRevs, LowPitch, HighPitch);
    }
}
