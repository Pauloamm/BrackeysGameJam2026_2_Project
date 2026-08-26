using UnityEngine;

public class EnemySkyCallingBehaviour : MonoBehaviour
{
    [SerializeField] private SkyShotProjectile skyShotPrefab;

    private Transform target;
    private float aoeRadius;
    private int aoeDamage;
    private float telegraphDuration;
    private float cooldownDuration;
    private float cooldownTimer;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void SetAoeRadius(float radius)
    {
        aoeRadius = radius;
    }

    public void SetAoeDamage(int damage)
    {
        aoeDamage = damage;
    }

    public void SetTelegraphDuration(float duration)
    {
        telegraphDuration = duration;
    }

    public void SetCooldownDuration(float duration)
    {
        cooldownDuration = duration;
    }

    private void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public bool IsOffCooldown()
    {
        return cooldownTimer <= 0f;
    }

    public void Fire()
    {
        SkyShotProjectile skyShot = Instantiate(skyShotPrefab, target.position, Quaternion.identity);
        skyShot.Initialize(aoeRadius, aoeDamage, telegraphDuration);

        cooldownTimer = cooldownDuration;
    }
}
