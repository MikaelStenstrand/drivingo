using UnityEngine;

/// <summary>
/// Runtime data for the ability 
/// </summary>
public class AbilityInfo : MonoBehaviour
{
    [Header("Runtime data for the ability")]
    //new public string name;
    //public string description;
    public string condition;
    public FloatReference DefaultSpeed = new FloatReference();
    public FloatReference ActiveSpeed = new FloatReference();
    public Transform[] Waypoints;
    public AbilityQueue AbilityQueue;
}
