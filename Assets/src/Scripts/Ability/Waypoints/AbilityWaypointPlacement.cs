using System;
using Drivingo.Event;
using UnityEngine;

namespace Drivingo.Ability
{
    public class AbilityWaypointPlacement : MonoBehaviour
    {
        [SerializeField]
        private BoolReference abilityWaypointPlacementProcedureActive;

        // general things for setting up waypoints
        // Guidance UI
        [SerializeField]
        private BoolReference setWaypointPlacement;

        private AbilityInfo abilityInfo;
        private int currentWaypointIndex = 0;


        /*
            - disable sprites
            - EVENT: Slow motion
                ::GameSpeedController
                    - listen to (true) abilityWaypointPlacementProcedureActive
                    - slow down
                    - listen to (false) abilityWaypointPlacementProcedureActive
                    - normal speed

            - START
                - EVENT: 
                    guidance UI
                    show sprite
                - Press button / double press = place waypoint
            - DESTINATION
                - EVENT: 
                    guidance UI
                    enable sprite
                - Press button / double press = place waypoint
            - EVENT: done - speed back to normal

        */

        private void Update()
        {
            if (abilityWaypointPlacementProcedureActive.Value)
            {
                if (IsAllWaypintsSet())
                {
                    abilityWaypointPlacementProcedureActive.Value = false;
                }
                else
                {
                    SetWaypointPlacement(currentWaypointIndex);
                }
            }
        }


        public void SetupWaypointPlacement(object[] args)
        {
            if (args == null || args[0] == null) return;
            abilityInfo = (AbilityInfo)args[0];

            abilityWaypointPlacementProcedureActive.Value = true;
            currentWaypointIndex = 0;
        }

        public void WaypointIsSet()
        {
            setWaypointPlacement.Value = false;
            AbilityWaypoint waypoint = abilityInfo.Waypoints[currentWaypointIndex].GetComponent<AbilityWaypoint>();
            waypoint.DoneSettingWaypointPlacement();
            currentWaypointIndex++;
        }



        private bool IsAllWaypintsSet()
        {
            AbilityWaypoint abilityWaypoint;
            foreach (var waypoint in abilityInfo.Waypoints)
            {
                abilityWaypoint = waypoint.GetComponent<AbilityWaypoint>();
                if (abilityWaypoint.isWaypointSet == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void SetWaypointPlacement(int index)
        {
            if (index < abilityInfo.Waypoints.Length)
            {
                setWaypointPlacement.Value = true;
                AbilityWaypoint waypoint = abilityInfo.Waypoints[index].GetComponent<AbilityWaypoint>();
                waypoint.EnableWaypointPlacement();
            }
        }




    }

}
