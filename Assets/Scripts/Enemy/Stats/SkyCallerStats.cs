using UnityEngine;

[CreateAssetMenu(fileName = "SkyCallerStats", menuName = "EnemyStats/Sky Caller Stats")]
public class SkyCallerStats : EnemyBaseStats
{
    public float stopDistance;
    public float telegraphDuration;
    public float aoeRadius;
    public int aoeDamage;
    public float fireCooldown;
}
