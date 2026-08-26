using UnityEngine;

[CreateAssetMenu(fileName = "ShooterStats", menuName = "EnemyStats/Shooter Stats")]
public class ShooterStats : EnemyBaseStats
{
    public float stopDistance;
    public float projectileSpeed;
    public float fireCooldown;
    public int projectileDamage;
}