using UnityEngine;
using System.Collections;

public class LoadMusic : MonoBehaviour
{

    public int HighScore = 0;
    AudioSource music;
    public static LoadMusic instance = null;

    /// <summary>
    /// keeps music playing and loads menu screen.
    /// </summary>
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

    /// <summary>
    /// updates high score if the player beats previous best
    /// </summary>
    /// <param name="score"></param>
    void UpdateHighScore(int score)
    {
        
        if (score > HighScore)
        {
            HighScore = score;
        }
    }
}
