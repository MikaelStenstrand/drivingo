using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 40f;

    private CharacterController2D characterController;
    private float horizontalMove = 0f;
    private bool jump = false;

    private void Awake()
    {
        characterController = gameObject.GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
