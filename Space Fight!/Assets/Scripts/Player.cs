using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public int currentHealth=100;
    public int damage = 50;
    public Object Explosion;

    // Use this for initialization
    void Start () {
    

    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void FixedUpdate()
    {
        

        // if player dies
        if (currentHealth <= 0)
        {
            
            Instantiate(Explosion, transform.position, transform.rotation);

            var GM = GameObject.FindGameObjectWithTag("GameManager");
            GM.SendMessage("UpdateGameOver", true);

            gameObject.SetActive(false);

           
        }
    }

    

    public void ApplyDamage(int value)
    {
        currentHealth -= value;
    }

}
