using UnityEngine;

public class EnemyDeathSfxPlayer : MonoBehaviour
{
    [SerializeField] private EnemyHealthSystem enemyHealth;
    [SerializeField] private PlayableSfxSettings deathSfx;

    private void OnEnable()
    {
        enemyHealth.OnDeath += PlayDeathSound;
    }

    private void OnDisable()
    {
        enemyHealth.OnDeath -= PlayDeathSound;
    }

    private void PlayDeathSound()
    {
        AudioManager.Instance.Play3DClip(deathSfx, transform.position);
    }
}