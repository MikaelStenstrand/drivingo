using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    private FloatReference walkingSpeed;

    public FloatReference WalkingSpeed { get => walkingSpeed; set => walkingSpeed = value; }
}
