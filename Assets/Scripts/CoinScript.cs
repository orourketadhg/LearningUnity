using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // public class variable
    // public make it so a variable can be seen in the script inspector
    public int Score;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Trigger When a 2D object collides with another 2D 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // will output a message into the console log
        Debug.Log("Ball has collided with coin");
 
        // will destroy the game object that this script is attached to
        Destroy(gameObject);

        // output Score to console
        Score++;
        Debug.Log("Score: " + Score);
        
    }
}
