using UnityEngine;

public class GameSpeedController : MonoBehaviour
{

    [SerializeField]
    private BoolReference abilityWaypointPlacementProcedureActive;
    [SerializeField]
    private FloatReference slowdownFactor = new FloatReference() { Value = 0.05f };

    private bool prevState;
    private float fixedDeltaTime;
    const float NORMAL_SPEED = 1.0f;

    private void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
        prevState = !abilityWaypointPlacementProcedureActive.Value;
    }

    private void Update()
    {
        if (abilityWaypointPlacementProcedureActive.Value != prevState)
        {
            if (abilityWaypointPlacementProcedureActive.Value)
            {
                SlowMotion();
            }
            else
            {
                NormalSpeed();
            }
            prevState = abilityWaypointPlacementProcedureActive.Value;
        }
    }

    private void SlowMotion()
    {
        Time.timeScale = slowdownFactor.Value;
    }

    private void NormalSpeed()
    {
        Time.timeScale = NORMAL_SPEED;
        Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
    }

}
