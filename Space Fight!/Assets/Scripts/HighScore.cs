using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    private GameObject gmo;
    
    // Use this for initialization
    void Start () {
        gmo = GameObject.Find("theAudioSource");
    }
    
    // Update is called once per frame
    void Update () {

       


        gameObject.GetComponent<Text>().text = "High Score " + gmo.GetComponent<LoadMusic>().HighScore;
        
        
        }
}
