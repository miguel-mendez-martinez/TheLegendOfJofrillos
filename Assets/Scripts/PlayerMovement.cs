using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to implement the 4way movement of the player.
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D playerRigidBody;
    private Vector3 positionChange;
    private Animator movementAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        movementAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// In the update method we will get the input from the axis and we will move the character depending on that input
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        positionChange = Vector3.zero;

        positionChange.x = Input.GetAxisRaw("Horizontal");
        positionChange.y = Input.GetAxisRaw("Vertical");

        if(positionChange != Vector3.zero)
        {
            //the player moves
            moveCharacter();

            //the animation gets updated
            movementAnimator.SetFloat("moveX", positionChange.x);
            movementAnimator.SetFloat("moveY", positionChange.y);
            movementAnimator.SetBool("isMoving", true);
        }
        else
        {
            movementAnimator.SetBool("isMoving", false);
        }
    }

    void moveCharacter()
    {
        //the character's rigidbody moves it to the direction it needs
        playerRigidBody.MovePosition(transform.position + speed * Time.deltaTime * positionChange);
    }
}
