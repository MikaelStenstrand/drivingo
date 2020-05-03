using Lean.Touch;
using UnityEngine;

public class AbilityWaypoint : MonoBehaviour
{
    public bool isWaypointSet = false;

    private SpriteRenderer sprite;
    private LeanSelectable leanSelectable;
    private LeanDragTranslate leanDrag;
    private AbilityQueue abilityQueue;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        leanSelectable = GetComponent<LeanSelectable>();
        leanDrag = GetComponent<LeanDragTranslate>();
        abilityQueue = GetComponentInParent<AbilityQueue>();
        EnableComponents(false);
    }

    public void EnableWaypointPlacement()
    {
        EnableComponents(true);
    }

    public void DoneSettingWaypointPlacement()
    {
        EnableComponents(false);
        isWaypointSet = true;
        if (abilityQueue != null)
        {
            abilityQueue.IsQueueActive = true;
        }
    }

    private void EnableComponents(bool active)
    {
        sprite.enabled = active;
        leanSelectable.enabled = active;
        leanDrag.enabled = active;
    }
}
