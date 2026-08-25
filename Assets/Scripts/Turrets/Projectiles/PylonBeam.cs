using UnityEngine;

public class PylonBeam : ProjectileBase
{
    [SerializeField] private float damageTickInterval = 0.5f;

    private float tickTimer;
    private float rotatedDegrees;

    public void Launch(float damage, float rotationSpeed, float length)
    {
        powerValue = damage;
        speed = rotationSpeed;

        transform.localScale = new Vector3(transform.localScale.x,length, transform.localScale.z);
    }

    protected override void Move()
    {
        float step = speed * Time.deltaTime;
        transform.Rotate(0f, 0f, step);
        rotatedDegrees += step;

        if (rotatedDegrees >= 360f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponentInChildren<IDamageable>();

        if (damageable == null) return;

        tickTimer -= Time.fixedDeltaTime;

        if (tickTimer > 0f) return;

        damageable.TakeDamage(Mathf.RoundToInt(powerValue));
        tickTimer = damageTickInterval;
    }
}
