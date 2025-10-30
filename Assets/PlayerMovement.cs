using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller; //to move we need a reference to character controller

    public float walkSpeed = 12f;
    public float sprintSpeed = 18f;

    private float realSpeed;

    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;   // the velocity until player arrive to the ground
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //take the above input and turn it into a direction that we want to move

        Vector3 move = transform.right * x + transform.forward * z; //this take the direction that the player is facing

        //Vector3 move = new Vector3(x, 0f, z);  //these global coordinates, and so we would always move in the same direction  no matter what way the player is facing



        //controller.Move(move * walkSpeed * Time.deltaTime); //time deltra time makes frame rate time independent
        realSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        if(Input.GetButtonDown("Jump")) // && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime); //we multiple once more with Time.deltaTime because of Dy = 1/2*g*t^2
    }

    void FixedUpdate()
     {
         transform.Translate(realSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, realSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
     }
}
