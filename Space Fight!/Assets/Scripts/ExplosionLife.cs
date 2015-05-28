using UnityEngine;
using System.Collections;

public class ExplosionLife : MonoBehaviour {

     public float lifeTime = 2.0f;
    private float startTime;
    private float checkTime;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (!gameObject.activeInHierarchy)
        {

        }
        else
        {
            if (startTime == 0f)
            {
                startTime = Time.time;
            }
            else
            {
                checkTime = Time.time - startTime;
                if (checkTime >= lifeTime)
                {
                    startTime = 0f;
                    Destroy(gameObject);

                }
            }
        }
    }
}
