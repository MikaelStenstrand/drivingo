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


    // TODO: double check that queue is not empty before pickup, if empty them, go into IDLE
    private void AbilityMovement()
    {
        if (abilityInfo.Waypoints.Length == 0) return;
        search = false;

        if (currentState == AbilityState.IDLE && abilityInfo.AbilityQueue.GetQueueLength() > 0)
        {
            currentState = AbilityState.PICKING_UP;
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

}
