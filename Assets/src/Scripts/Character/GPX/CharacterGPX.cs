using UnityEngine;
using Pathfinding;
using System;

public class CharacterGPX : MonoBehaviour
{
    private AIPath aIPath;
    private bool isFacingRight = true;

    private void Start()
    {
        aIPath = GetComponentsInParent<AIPath>()[0];
    }

    void Update()
    {
        if (aIPath.desiredVelocity.x >= 0.01f && !isFacingRight || aIPath.desiredVelocity.x <= -0.01f && isFacingRight)
        {
            FlipGPX(isFacingRight);
        }
    }

    private void FlipGPX(bool faceRight)
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = !faceRight;
    }
}
