using UnityEngine;

public abstract class TurretBaseStats : ScriptableObject
{
    public float damage;
    public float cooldownDuration;
    public float projectileSpeed;
    public int overchargeStacks;
}
