using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D), typeof(CharacterInfo))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float movementAmplifier = 10;

    private CharacterInfo characterInfo;
    private CharacterController2D characterController;

    private void Awake()
    {
        characterInfo = gameObject.GetComponent<CharacterInfo>();
        characterController = gameObject.GetComponent<CharacterController2D>();
    }

    private void Update()
    {
    }

    private float GetHorizontalSpeed()
    {
        // basic forward walking for now
       return characterInfo.WalkingSpeed * movementAmplifier * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        characterController.Move(GetHorizontalSpeed(), false, false);
    }
}
