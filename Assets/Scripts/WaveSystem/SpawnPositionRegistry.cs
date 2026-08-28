using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionRegistry
{
    private const float MinDistanceBetweenTelegraphs = 1f;

    private readonly List<Vector2> pendingPositions = new List<Vector2>();

    public bool TryReservePosition(Vector2 candidate)
    {
        foreach (Vector2 pendingPosition in pendingPositions)
        {
            if (Vector2.Distance(candidate, pendingPosition) < MinDistanceBetweenTelegraphs)
            {
                return false;
            }
        }

        pendingPositions.Add(candidate);
        return true;
    }

    public void ReleasePosition(Vector2 position)
    {
        pendingPositions.Remove(position);
    }
}