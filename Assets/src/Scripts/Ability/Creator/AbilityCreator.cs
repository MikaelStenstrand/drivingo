using UnityEngine;

/// <summary>
/// Creates all neccessary components and waypoints for the ability
/// Destorys itself upon completion
/// </summary>
public class AbilityCreator : MonoBehaviour
{
    private AbilitySpec abilitySpec;
    private Vector3 positionOutsideOfScreen;
    private AbilityInfo abilityInfo;

    private void Start()
    {
        positionOutsideOfScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        positionOutsideOfScreen.z = 0;
        CreateAbilityGOs();
        PopulateAbilityInfo(abilityInfo);
        InitWaypoints(abilityInfo);
        abilitySpec.WaypointPlacementEvent.Raise(abilityInfo);
        Destroy(gameObject, 2.0f);
    }

    public void setAbilitySpec(AbilitySpec spec)
    {
        abilitySpec = spec;
    }

    private void CreateAbilityGOs()
    {
        GameObject GO = Instantiate(abilitySpec.AbilityControllerPrefab, positionOutsideOfScreen, Quaternion.identity);
        GameObject GPXGO = Instantiate(abilitySpec.CharacterPrefab, positionOutsideOfScreen, Quaternion.identity);
        GPXGO.transform.SetParent(GO.transform);

        abilityInfo = GO.GetComponent<AbilityInfo>();
    }

    private void PopulateAbilityInfo(AbilityInfo info)
    {
        if (info != null)
        {
            info.AbilityName = abilitySpec.Name;
            info.Description = abilitySpec.Description;
            info.Condition = abilitySpec.Condition;
            info.DefaultSpeed = abilitySpec.DefaultSpeed;
            info.ActiveSpeed = abilitySpec.ActiveSpeed;
        }
    }

    private void InitWaypoints(AbilityInfo info)
    {
        GameObject waypointsGO = Instantiate(abilitySpec.WaypointsPrefab, Vector3.zero, Quaternion.identity);
        AbilityQueue queue = waypointsGO.GetComponentInChildren<AbilityQueue>();
        int count = waypointsGO.transform.childCount;
        Transform[] waypoints = new Transform[count];

        if (queue != null)
        {
            info.AbilityQueue = queue;
        }

        for (int i = 0; i < count; i++)
        {
            waypoints[i] = waypointsGO.transform.GetChild(i);
        }
        info.Waypoints = waypoints;
    }


}
