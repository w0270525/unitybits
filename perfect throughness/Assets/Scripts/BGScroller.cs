using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{


    public float scrollSpeed; //speed in which the background will move.
    public float tileSizeY; //size of the background sprite.


    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {

        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.up * newPosition;
    }
}
