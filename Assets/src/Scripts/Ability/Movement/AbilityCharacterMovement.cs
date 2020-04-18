using UnityEngine;
using Pathfinding;
using System;

[RequireComponent(typeof(AbilityInfo), typeof(IAstarAI), typeof(PickupController))]
public class AbilityCharacterMovement : MonoBehaviour
{
    [SerializeField]
    private bool loop;

    private PickupController pickupController;
    private AbilityInfo abilityInfo;
    private IAstarAI pathfinderAgent;
    private int currentWaypointIndex = 0;
    private bool isMovementTowardsDestination = true;
    float switchTime = float.PositiveInfinity;
    private bool search;
    private bool isActive;
    // TODO: Trigger event / call function when destination reached

    private void Awake()
    {
        pickupController = gameObject.GetComponent<PickupController>();
        abilityInfo = gameObject.GetComponent<AbilityInfo>();
        pathfinderAgent = gameObject.GetComponent<IAstarAI>();
    }

    private void Start()
    {
        SetAbilitySpeed();
    }

    private void FixedUpdate()
    {
        MoveThroughWaypoints();
    }


    private void MoveThroughWaypoints()
    {
        if (abilityInfo.Waypoints.Length == 0) return;
        search = false;

        if (pathfinderAgent.reachedEndOfPath && !pathfinderAgent.pathPending && float.IsPositiveInfinity(switchTime))
        {
            switchTime = Time.time;
        }

        if (Time.time >= switchTime)
        {
            currentWaypointIndex = isMovementTowardsDestination ? currentWaypointIndex + 1 : currentWaypointIndex - 1;
            search = true;
            switchTime = float.PositiveInfinity;
        }

        if (IsDestinationReached())
        {
            DestinationReached();
            return;
        }

        pathfinderAgent.destination = abilityInfo.Waypoints[currentWaypointIndex].position;

        if (search)
            pathfinderAgent.SearchPath();
    }

    private bool IsDestinationReached()
    {
        return IsAtDestination() || IsAtStart();
    }
    private bool IsAtDestination()
    {
        return currentWaypointIndex >= abilityInfo.Waypoints.Length && isMovementTowardsDestination;
    }
    private bool IsAtStart()
    {
        return currentWaypointIndex < 0 && !isMovementTowardsDestination;
    }

    private void SetAbilitySpeed()
    {
        if (isActive)
        {
            pathfinderAgent.maxSpeed = abilityInfo.ActiveSpeed.Value;
        }
        else
        {
            pathfinderAgent.maxSpeed = abilityInfo.DefaultSpeed.Value;
        }
    }

    private void Pickup()
    {
        pickupController.PickUp();
        isActive = true;
    }
    private void DropOff()
    {
        pickupController.DropOff();
        isActive = false;
    }

    private void DestinationReached()
    {
        if (loop)
        {
            if (IsAtDestination())
            {
                Debug.Log("destination reached: movementRight:: " + isMovementTowardsDestination + ", " + currentWaypointIndex);
                DropOff();
                SetAbilitySpeed();
                isMovementTowardsDestination = false;

                return;
            }
            else if (IsAtStart())
            {
                Debug.Log("Start: movementRight:: " + isMovementTowardsDestination + ", " + currentWaypointIndex);
                Pickup();
                SetAbilitySpeed();
                isMovementTowardsDestination = true;

                return;
            }
        }
    }
}
