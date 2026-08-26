using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PylonBeam : ProjectileBase
{
    [SerializeField] private float damageTickInterval = 0.5f;

    private Dictionary<IDamageable, float> tickTimers = new Dictionary<IDamageable, float>();
    private float rotatedDegrees;

    public void Launch(float damage, float rotationSpeed, float length)
    {
        powerValue = damage;
        speed = rotationSpeed;

        transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);
    }

    override protected void Update()
    {
        base.Update();
        
        foreach (IDamageable key in tickTimers.Keys.ToList())
            tickTimers[key] -= Time.deltaTime;
        
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

        if (!tickTimers.ContainsKey(damageable))
            tickTimers[damageable] = 0f;
        

        if (tickTimers[damageable] > 0f) return;

        damageable.TakeDamage(Mathf.RoundToInt(powerValue));
        tickTimers[damageable] = damageTickInterval;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponentInChildren<IDamageable>();

        if (damageable == null) return;

        tickTimers.Remove(damageable);
    }
}