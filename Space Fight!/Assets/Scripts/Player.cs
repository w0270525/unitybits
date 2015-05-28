using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public int currentHealth=100;
    public int damage = 50;
    public int score = 0;

    // Use this for initialization
    void Start () {
    

    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void FixedUpdate()
    {
        var scoreObject = GameObject.FindGameObjectWithTag("Score");
        scoreObject.GetComponent<Text>().text = "Score " + score;
    }

    public void UpdateScore(int newScore)
    {
        score += newScore;
    }
}
