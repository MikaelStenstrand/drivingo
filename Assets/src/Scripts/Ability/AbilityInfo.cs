using UnityEngine;

/// <summary>
/// Runtime data for the ability 
/// </summary>
public class AbilityInfo : MonoBehaviour
{
    [Header("Runtime data for the ability")]
    public string AbilityName;
    public string Description;
    public string Condition;
    public FloatReference DefaultSpeed = new FloatReference();
    public FloatReference ActiveSpeed = new FloatReference();
    public Transform[] Waypoints;
    public AbilityQueue AbilityQueue;
}
