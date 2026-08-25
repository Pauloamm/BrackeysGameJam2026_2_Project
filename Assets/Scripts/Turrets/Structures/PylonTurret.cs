using UnityEngine;

public class PylonTurret : TurretBase<PylonStats>
{
    [SerializeField] private float overchargeLengthPerStack = 1f;
    [SerializeField] private PylonBeam beamPrefab;

    protected override void Fire()
    {
        float effectiveBeamRange = currentStats.beamRange + (currentStats.overchargeStacks * overchargeLengthPerStack);
        float anglePerBeam = 360f / currentStats.beamCount;

        for (int i = 0; i < currentStats.beamCount; i++)
        {
            PylonBeam beam = Instantiate(beamPrefab, transform.position, Quaternion.Euler(0f, 0f, anglePerBeam * i));
            beam.Launch(currentStats.damage, currentStats.projectileSpeed, effectiveBeamRange);
        }
    }

    protected override float GetCooldownDuration()
    {
        return currentStats.cooldownDuration;
    }
}