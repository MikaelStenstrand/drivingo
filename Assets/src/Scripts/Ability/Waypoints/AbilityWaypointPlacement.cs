using UnityEngine;

namespace Drivingo.Ability
{
    public class AbilityWaypointPlacement : MonoBehaviour
    {
        [SerializeField]
        private BoolReference abilityWaypointPlacementProcedureActive;

        [SerializeField]
        private BoolReference setWaypointPlacement;

        private AbilityInfo abilityInfo;
        private int currentWaypointIndex = 0;

        private void Update()
        {
            if (abilityWaypointPlacementProcedureActive.Value)
            {
                if (IsAllWaypintsSet())
                {
                    abilityWaypointPlacementProcedureActive.Value = false;
                    // add visualization of newly created ability
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
