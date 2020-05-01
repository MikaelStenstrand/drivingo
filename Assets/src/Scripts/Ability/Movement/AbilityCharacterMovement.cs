using UnityEngine;
using Pathfinding;
using System;

public enum AbilityState
{
    IDLE,
    PICKING_UP,
    DELIVERING
}


[RequireComponent(typeof(AbilityInfo), typeof(IAstarAI), typeof(PickupController))]
public class AbilityCharacterMovement : MonoBehaviour
{
    [SerializeField]
    private bool loop;
    [SerializeField]
    private float delayAtWaypoint = 1.0f;

    private PickupController pickupController;
    private AbilityInfo abilityInfo;
    private IAstarAI pathfinderAgent;
    private int currentWaypointIndex = 0;
    private AbilityState currentState;
    private bool isMovementTowardsDestination = false;
    float switchTime = float.PositiveInfinity;
    private bool search = false;
    private bool isActive = false;
    // TODO: Trigger event / call function when destination reached

    const int START_INDEX = 0;
    const int DESTINATION_INDEX = 1;

    private void Awake()
    {
        pickupController = gameObject.GetComponent<PickupController>();
        abilityInfo = gameObject.GetComponent<AbilityInfo>();
        pathfinderAgent = gameObject.GetComponent<IAstarAI>();
    }

    private void Start()
    {
        SetAbilitySpeed();
        currentState = AbilityState.IDLE;
    }

    private void FixedUpdate()
    {
        AbilityMovement();
    }

    private void AbilityMovement()
    {
        if (abilityInfo.Waypoints.Length == 0) return;
        search = false;

        if (currentState == AbilityState.IDLE && abilityInfo.AbilityQueue.GetQueueLength() > 0)
        {
            currentState = AbilityState.PICKING_UP;
            Debug.Log("Queue: " + abilityInfo.AbilityQueue.GetQueueLength());
        }

        if (IsWaypointReached())
        {
            switchTime = Time.time + delayAtWaypoint;
            if (currentState == AbilityState.PICKING_UP)
            {
                // at start
                Pickup();
                SetAbilitySpeed();
                currentState = AbilityState.DELIVERING;
            }
            else if (currentState == AbilityState.DELIVERING)
            {
                // at destination
                DropOff();
                SetAbilitySpeed();
                currentState = AbilityState.IDLE;
            }
        }
        if (currentState == AbilityState.PICKING_UP)
        {
            MoveToWaypointIndex(START_INDEX);
        }
        else if (currentState == AbilityState.DELIVERING)
        {
            MoveToWaypointIndex(DESTINATION_INDEX);
        }
    }

    private bool IsWaypointReached()
    {
        return pathfinderAgent.reachedEndOfPath && !pathfinderAgent.pathPending && float.IsPositiveInfinity(switchTime);
    }

    private void MoveToWaypointIndex(int index)
    {
        if (Time.time >= switchTime)
        {
            currentWaypointIndex = index;
            search = true;
            switchTime = float.PositiveInfinity;
        }
        currentWaypointIndex = currentWaypointIndex % abilityInfo.Waypoints.Length;
        pathfinderAgent.destination = abilityInfo.Waypoints[currentWaypointIndex].position;

        if (search) pathfinderAgent.SearchPath();
    }

    // private void MoveThroughWaypoints()
    // {
    //     if (abilityInfo.Waypoints.Length == 0) return;
    //     // if (abilityInfo.AbilityQueue.GetQueueLength() <= 0)
    //     // {
    //     //     // TODO: bug when picking up the last one in the queue
    //     //     return;
    //     // }
    //     search = false;

    //     if (pathfinderAgent.reachedEndOfPath && !pathfinderAgent.pathPending && float.IsPositiveInfinity(switchTime))
    //     {
    //         switchTime = Time.time;
    //     }

    //     if (Time.time >= switchTime)
    //     {
    //         currentWaypointIndex = isMovementTowardsDestination ? currentWaypointIndex + 1 : currentWaypointIndex - 1;
    //         search = true;
    //         switchTime = float.PositiveInfinity;
    //     }

    //     if (IsDestinationReached())
    //     {
    //         DestinationReached();
    //         return;
    //     }

    //     if (currentWaypointIndex >= 0 && currentWaypointIndex < abilityInfo.Waypoints.Length)
    //     {
    //         Debug.Log("Moving towards: " + currentWaypointIndex);
    //         pathfinderAgent.destination = abilityInfo.Waypoints[currentWaypointIndex].position;
    //     }
    //     else
    //     {
    //         Debug.LogError("PathfinderAgent: Out of bounce");
    //     }

    //     if (search)
    //     {
    //         pathfinderAgent.SearchPath();
    //     }

    // }

    // private bool IsDestinationReached()
    // {
    //     return IsAtDestination() || IsAtStart();
    // }
    // private bool IsAtDestination()
    // {
    //     return currentWaypointIndex >= abilityInfo.Waypoints.Length && isMovementTowardsDestination;
    // }
    // private bool IsAtStart()
    // {
    //     return currentWaypointIndex < 0 && !isMovementTowardsDestination;
    // }

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

    // private void DestinationReached()
    // {
    //     if (loop)
    //     {
    //         if (IsAtDestination())
    //         {
    //             Debug.Log("destination reached: movementRight:: " + isMovementTowardsDestination + ", " + currentWaypointIndex);
    //             DropOff();
    //             SetAbilitySpeed();
    //             isMovementTowardsDestination = false;

    //             return;
    //         }
    //         else if (IsAtStart())
    //         {
    //             Debug.Log("Start: movementRight:: " + isMovementTowardsDestination + ", " + currentWaypointIndex);
    //             Pickup();
    //             SetAbilitySpeed();
    //             isMovementTowardsDestination = true;

    //             return;
    //         }
    //     }
    // }
}
