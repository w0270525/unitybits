using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{

    private Transform thisTransform = null;


    // Use this for initialization
    void Start()
    {

        //Cache transform

        thisTransform = transform;

    }

    // Update is called once per frame
    void LateUpdate() {
	
        //Billboard sprite
        var lookAtDir = new Vector3(Camera.main.transform.position.x - thisTransform.position.x, 0, Camera.main.transform.position.z - thisTransform.position.z);
        thisTransform.rotation = Quaternion.LookRotation(lookAtDir.normalized, Vector3.up);
	}
}
