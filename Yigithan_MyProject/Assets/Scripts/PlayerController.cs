using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Force based controls are not suited for this project
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 playerVelocity;

    private bool groundedPlayer;
    public float playerSpeed = 15.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    //Scene Boundary Paramaters
    private float zBoundary_top = 19.1f;
    private float zBoundary_bottom = -0.5f;
    private float xBoundary_right = 18.3f;
    private float xBoundary_left = -17.6f;
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }
    void Update()
    {
        PlayerMove();
        ConstrainPlayerPos();      
    }
    //Constrain Game Boundries Top Bottom Left Right
    void ConstrainPlayerPos()
    {
        if (transform.position.z < zBoundary_bottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary_bottom);
        }
        if (transform.position.z > zBoundary_top)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundary_top);
        }

        if (transform.position.x < xBoundary_left)
        {
            transform.position = new Vector3(xBoundary_left, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBoundary_right)
        {
            transform.position = new Vector3(xBoundary_right, transform.position.y, transform.position.z);
        }
    }
    //Player Movement Function
    void PlayerMove() 
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
