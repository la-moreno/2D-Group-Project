using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float MOVEMENT_BASE_SPEED = 1.0f;

    //For direction
    public Vector2 movementDirection;

    //For speed (the further the stick is pushed the faster the character moves)
    public float movementSpeed = 1f;

    //To access rigidbody
    public Rigidbody2D rb;          //Drag and drop the rigidbody to the script rb field

    //-----------------------------------------------------
    //For keyboard movement
    Vector2 keyMovement;


    //For animating
    public Animator animator;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float runSpeed = 1f;

    //For soundFX
    float StepInterval = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //So inputs are processed in every frame
        ProcessInputs();
        

        //For animation
        //Horizontal move
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", horizontalMove);

        //Vertical move
        verticalMove = Input.GetAxisRaw("Vertical");
        animator.SetFloat("VerticalSpeed", verticalMove);
    }
    //-------------------------------------keyboard
    void FixedUpdate()
    {
        Move();

        rb.MovePosition(rb.position + keyMovement * movementSpeed);
    }

    //for handling input
    void ProcessInputs()
    {
        //Game controller
        //Apply values to movementDirection based on player input
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, .1f);           //Clamp controller input at 0 through 1
        movementDirection.Normalize();

        //Playing the walking sound(JOEL)
        if(movementSpeed > 0)
        {
            if (StepInterval < Time.time)
            {
                FindObjectOfType<AudioManger>().Play("FootSteps");
                StepInterval = Time.time + 0.4f;
            }
        }

        //----------------------keyboard
        keyMovement.x = Input.GetAxisRaw("Horizontal");
        keyMovement.y = Input.GetAxisRaw("Vertical");

    }


    //Change players speed according to input
    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }
}
