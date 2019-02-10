using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    // any object in a scene that can have a position, a scale and a rotation
    public Transform groundCheckPoint;
    // radius of player object from middle
    public float groundCheckRadius;
    //user layers
    public LayerMask groundLayer;
    private bool isTouchingGround;

    // Start is called before the first frame update
    void Start()
    {
        // gets the attached gameObjects RigidBody2D 
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // returns true, if around a radius from the transform positon the gameObejct is overlaping the specified layer 
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        // gets the Horizontal input key on the horizontal axis (arrowLeft/arrowRight/a/d)
        // these input values are either 1 or -1 for positive horizontal and negitive horizontal
        movement = Input.GetAxis("Horizontal");

        //Debug.Log(movement);

        // This way of adding motion has problems, in when there is no key pressed, the x value will always be 0 leaving no horizontal momentum
        // add velocity in the x axis and maintain y axis value

        // by adding an if condition the new vector will only occur when the button is pressed(via checking the movement variable)
        if (movement > 0f || movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);

        }

        // when space is held down - Jump
        // Note: the jump key will only activate once per time it is pressed down.
        if (Input.GetButtonDown("Jump") && isTouchingGround == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);

        }
        
    }
}
