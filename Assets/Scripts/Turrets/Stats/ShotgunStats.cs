using UnityEngine;

[CreateAssetMenu(fileName = "ShotgunStats", menuName = "TurretStats/ShotgunStats")]
public class ShotgunStats : TurretBaseStats
{
    public int pelletCount;
    public float coneAngle;
    public int pierceCount;
    public float range;
}
