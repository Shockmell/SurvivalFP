using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    #region Private
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float gravity = 20f;
    private float verticalVelocity;
    #endregion

    #region Public
    public float speed = 5f;
    public float jumpForce = 10f;
    #endregion
    #endregion

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveThePlayer();
    }

    #region Custom Functions
    void MoveThePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();
        characterController.Move(moveDirection);
    }

    void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }

        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if(characterController.isGrounded)
        {
            verticalVelocity = jumpForce;
        }
    }
    #endregion
}
