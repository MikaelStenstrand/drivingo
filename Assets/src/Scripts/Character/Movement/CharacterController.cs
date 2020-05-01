using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(CharacterInfo), typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float movementAmplifier = 10;
    [SerializeField]
    private float queueMovementSpeed = 0.02f;

    private Rigidbody2D rb;
    private CharacterInfo characterInfo;
    private CharacterMovement characterController;
    public CharacterState CharacterState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterInfo = GetComponent<CharacterInfo>();
        characterController = GetComponent<CharacterMovement>();
    }

    private void Start()
    {
        CharacterState = CharacterState.WALKING;
    }

    private void FixedUpdate()
    {
        if (CharacterState == CharacterState.WALKING)
        {
            characterController.Move(GetHorizontalSpeed(), false, false);
        }
        else if (CharacterState == CharacterState.IN_QUEUE)
        {
            characterController.Move(queueMovementSpeed, false, false);
        }
        else if (CharacterState == CharacterState.ABILITY_ACTIVE)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
            characterController.Move(0.0f, false, false);
        }
    }

    private float GetHorizontalSpeed()
    {
        // basic forward walking for now
        return characterInfo.WalkingSpeed * movementAmplifier * Time.fixedDeltaTime;
    }

}
