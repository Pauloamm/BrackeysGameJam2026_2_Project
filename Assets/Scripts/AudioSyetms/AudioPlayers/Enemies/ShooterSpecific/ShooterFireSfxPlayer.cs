using UnityEngine;

public class ShooterFireSfxPlayer : MonoBehaviour
{
    [SerializeField] private EnemyShootingBehaviour shootingBehaviour;
    [SerializeField] private PlayableSfxSettings fireSfx;

    private void OnEnable()
    {
        shootingBehaviour.OnFire += PlayFireSound;
    }

    private void OnDisable()
    {
        shootingBehaviour.OnFire -= PlayFireSound;
    }

    private void PlayFireSound()
    {
        AudioManager.Instance.Play3DClip(fireSfx, transform.position);
    }
}
