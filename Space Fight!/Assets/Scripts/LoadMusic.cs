using UnityEngine;
using System.Collections;

public class LoadMusic : MonoBehaviour {
    AudioSource music;
    public static LoadMusic instance = null;
    void Awake()
    {


        if (instance == null)
        {
            instance = this;


        }
        else if (instance != this)
            Destroy(gameObject);
            
        DontDestroyOnLoad(gameObject);
        Application.LoadLevel(1);
    }
}
