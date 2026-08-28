using UnityEngine;

public class SkyShotTelegraphSfxPlayer : MonoBehaviour
{
    [SerializeField] private SkyShotProjectile skyShotProjectile;
    [SerializeField] private PlayableSfxSettings telegraphStartSfx;
    [SerializeField] private PlayableSfxSettings telegraphEndSfx;

    private void OnEnable()
    {
        skyShotProjectile.OnTelegraphStart += PlayTelegraphStartSound;
        skyShotProjectile.OnTelegraphEnd += PlayTelegraphEndSound;
    }

    private void OnDisable()
    {
        skyShotProjectile.OnTelegraphStart -= PlayTelegraphStartSound;
        skyShotProjectile.OnTelegraphEnd -= PlayTelegraphEndSound;
    }

    private void PlayTelegraphStartSound()
    {
        AudioManager.Instance.Play3DClip(telegraphStartSfx, transform.position);
    }

    private void PlayTelegraphEndSound()
    {
        AudioManager.Instance.Play3DClip(telegraphEndSfx, transform.position);
    }
}
