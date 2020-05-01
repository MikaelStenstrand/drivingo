using System;
using UnityEngine;

/// <summary>
/// Creates all neccessary components and waypoints for the ability
/// Destorys itself upon completion
/// </summary>
public class AbilityCreator : MonoBehaviour
{
    public string condition { private get; set; }

    // private Ability ability;
    private WaypointController waypointController;

    private void Start()
    {
        // ability = gameObject.AddComponent(typeof(Ability)) as Ability;
        waypointController = gameObject.AddComponent(typeof(WaypointController)) as WaypointController;
        InitSequence();
    }

    private void InitSequence()
    {
        InitWaypointsGO();
    }

    private void InitWaypointsGO()
    {
        // waypointController.InitWaypointsGO();
    }


}
