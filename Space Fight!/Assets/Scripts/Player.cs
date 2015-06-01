using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public int currentHealth=100;
    public int damage = 50;
    public int score = 0;
    public Object Explosion;

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

        // if player dies
        if (currentHealth <= 0)
        {
            
            Instantiate(Explosion, transform.position, transform.rotation);
      
            var gameover = new GUIText();
            gameover.text = "Game Over \nPlay Again? Y/N ";

            GameOverChoice();
        }
    }

    private void GameOverChoice()
    {
        
        if (Input.GetButton("y"))
        {
            var reload = Application.loadedLevel;
            Application.LoadLevel(reload);
        }
    }

    public void ApplyDamage(int value)
    {
        currentHealth -= value;
    }
    public void UpdateScore(int newScore)
    {
        score += newScore;
    }
}
