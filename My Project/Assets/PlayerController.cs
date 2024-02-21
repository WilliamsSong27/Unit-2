using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * horizontalInput;
        Vector3 moveVertical = transform.forward * verticalInput;

        moveDirection = moveHorizontal + moveVertical;
        moveDirection.Normalize();

        moveDirection *= movementSpeed;

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void HandleJump()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2f * jumpHeight * gravity);
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
    }
}
