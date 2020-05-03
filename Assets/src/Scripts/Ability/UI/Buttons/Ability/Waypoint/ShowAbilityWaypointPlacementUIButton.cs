using System;
using Doozy.Engine;
using UnityEngine;

public class ShowAbilityWaypointPlacementUIButton : MonoBehaviour
{
    [SerializeField]
    private BoolReference uiEnabler;

    private string SHOW_ABILITY_WAYPOINT_VIEW_EVENT = "ShowAbilityWaypointView";
    private string HIDE_ABILITY_WAYPOINT_VIEW_EVENT = "HideAbilityWaypointView";

    private bool prevState = false;

    private void Update()
    {
        if (uiEnabler.Value != prevState)
        {
            ToggleUI(uiEnabler.Value);
        }
    }

    private void ToggleUI(bool value)
    {
        if (value)
        {
            GameEventMessage.SendEvent(SHOW_ABILITY_WAYPOINT_VIEW_EVENT);
        }
        else
        {
            GameEventMessage.SendEvent(HIDE_ABILITY_WAYPOINT_VIEW_EVENT);
        }
        prevState = uiEnabler.Value;
    }
}
