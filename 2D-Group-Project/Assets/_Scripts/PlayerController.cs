using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MOVEMENT_BASE_SPEED = 1.0f;

    //For direction
    public Vector2 movementDirection;

    //For speed (the further the stick is pushed the faster the character moves)
    public float movementSpeed;

    //To access rigidbody
    public Rigidbody2D rb;          //Drag and drop the rigidbody to the script rb field


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //So inputs are processed in every frame
        ProcessInputs();
        Move();
    }

    //for handling input
    void ProcessInputs()
    {
        //Apply values to movementDirection based on player input
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);           //Clamp controller input at 0 through 1
        movementDirection.Normalize();
    }


    //Change players speed according to input
    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }
}
