using UnityEngine;

public class PlayerSFXPlayer : MonoBehaviour
{
    [SerializeField] private PlayerLifeManager playerLifeManager;
    [SerializeField] private ShieldManager shieldManager;

    [SerializeField] private PlayableSfxSettings shieldLostSfx;
    [SerializeField] private PlayableSfxSettings healthLostSfx;
    [SerializeField] private PlayableSfxSettings deathSfx;

    private void OnEnable()
    {
        shieldManager.OnShieldConsumed += PlayShieldLostSound;
        playerLifeManager.OnHealthLost += PlayHealthLostSound;
        playerLifeManager.OnDeath += PlayDeathSound;
    }

    private void OnDisable()
    {
        shieldManager.OnShieldConsumed -= PlayShieldLostSound;
        playerLifeManager.OnHealthLost -= PlayHealthLostSound;
        playerLifeManager.OnDeath -= PlayDeathSound;
    }

    private void PlayShieldLostSound()
    {
        AudioManager.Instance.Play2DClip(shieldLostSfx);
    }

    private void PlayHealthLostSound()
    {
        AudioManager.Instance.Play2DClip(healthLostSfx);
    }

    private void PlayDeathSound()
    {
        AudioManager.Instance.Play2DClip(deathSfx);
    }
}
