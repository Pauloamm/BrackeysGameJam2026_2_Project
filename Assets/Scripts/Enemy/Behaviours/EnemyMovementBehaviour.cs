using UnityEngine;

public class EnemyMovementBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDistance;
    [SerializeField] private Transform thisEnemyTransform;

    private Transform target;

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetStopDistance(float distance)
    {
        stopDistance = distance;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public bool IsWithinStopDistance()
    {
        return Vector2.Distance(thisEnemyTransform.position, target.position) <= stopDistance;
    }

    public void MoveTowardsTarget()
    {
        Vector2 direction = ((Vector2)target.position - (Vector2)thisEnemyTransform.position).normalized;
        thisEnemyTransform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
}
