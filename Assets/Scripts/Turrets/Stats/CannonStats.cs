using UnityEngine;

[CreateAssetMenu(fileName = "CannonStats", menuName = "TurretStats/CannonStats")]
public class CannonStats : TurretBaseStats
{
    public int bounceCount;
    public float range = 5f;
}