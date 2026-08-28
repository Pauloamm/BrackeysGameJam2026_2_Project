using UnityEngine;

public class EnemyDamagedSfxPlayer : MonoBehaviour
{
    [SerializeField] private EnemyHealthSystem enemyHealth;
    [SerializeField] private PlayableSfxSettings damagedSfx;

    private void OnEnable()
    {
        enemyHealth.OnDamaged += PlayDamagedSound;
    }

    private void OnDisable()
    {
        enemyHealth.OnDamaged -= PlayDamagedSound;
    }

    private void PlayDamagedSound()
    {
        AudioManager.Instance.Play3DClip(damagedSfx, transform.position);
    }
}
