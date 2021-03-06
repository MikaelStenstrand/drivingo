﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AbilityInfo))]
public class PickupController : MonoBehaviour
{
    [SerializeField]
    private float pickupOffset = 1.5f;

    private AbilityInfo abilityInfo;
    private AbilityQueue abilityQueue;

    private GameObject currentPickup;

    void Start()
    {
        currentPickup = null;
        abilityInfo = GetComponent<AbilityInfo>();
        abilityQueue = abilityInfo.AbilityQueue;
    }

    public void PickUp()
    {
        if (abilityQueue.GetQueueLength() > 0 && currentPickup == null)
        {
            currentPickup = abilityQueue.LeaveQueue();
            currentPickup.GetComponent<CharacterController>().CharacterState = CharacterState.ABILITY_ACTIVE;
            AttachPickupToGO(currentPickup);
        }
    }

    private void AttachPickupToGO(GameObject pickup)
    {
        pickup.transform.SetParent(transform);
        pickup.transform.localPosition = new Vector3(0, transform.localPosition.y + pickupOffset, 0);

        pickup.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    private void DetatchPickup()
    {
        currentPickup.transform.localPosition = new Vector3(0, transform.localPosition.y - pickupOffset * 2, 0);
        currentPickup.transform.SetParent(null);
        currentPickup.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        currentPickup = null;
    }

    public void DropOff()
    {
        if (currentPickup != null)
        {
            currentPickup.GetComponent<CharacterController>().CharacterState = CharacterState.WALKING;
            DetatchPickup();
        }
    }

}
