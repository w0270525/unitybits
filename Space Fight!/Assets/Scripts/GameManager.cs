using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int HighScore;
    public bool GameOver;
    public int Score;



    public GameObject scoreObject;
    public GameObject gameOverObject;
    public GameObject highScoreObject;

    void Awake()
    {
        GameOver = false;
    }

    /// <summary>
    /// updates score/gameover stuff.
    /// </summary>
    void FixedUpdate()
    {
        scoreObject = GameObject.FindGameObjectWithTag("Score");
        scoreObject.GetComponent<Text>().text = "Score " + Score;

        if (GameOver == true)
        {
            //updates high score if necessary
            highScoreObject = GameObject.FindGameObjectWithTag("Audio");

            highScoreObject.SendMessage("UpdateHighScore", Score);


            //brings up game over option
            var gover = GameObject.FindGameObjectWithTag("GameOver");
            
            gover.GetComponent<CanvasGroup>().alpha = 1f;
            gover.GetComponent<CanvasGroup>().interactable = true;





        }
    }


    /// <summary>
    /// listener to add points achieved to current score
    /// </summary>
    /// <param name="newScore"></param>
    public void UpdateScore(int newScore)
    {
        Score += newScore;
    }

    /// <summary>
    /// listener for changing game over status
    /// </summary>
    /// <param name="goSetting"></param>
    public void UpdateGameOver(bool goSetting)
    {
        GameOver = goSetting;
    }

}

