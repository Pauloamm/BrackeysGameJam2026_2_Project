using UnityEngine;

public static class EnemySpawnPositionUtil
{
    public static Vector2 GetRandomPositionAroundTarget(Transform target, float minDistance, float maxDistance)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float distance = Random.Range(minDistance, maxDistance);

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        return (Vector2)target.position + direction * distance;
    }
}
