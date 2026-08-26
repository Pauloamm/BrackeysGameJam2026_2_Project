using UnityEngine;

public class EnemyContactDamageBehaviour : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private int contactDamage;

    public void SetContactDamage(int damage)
    {
        contactDamage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;


        IDamageable damageable = other.GetComponentInChildren<IDamageable>();
        damageable.TakeDamage(contactDamage);

    }
}
