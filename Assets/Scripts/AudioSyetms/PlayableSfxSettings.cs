using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayableSfxSettings", menuName = "Audio/Playable Sfx Settings")]
public class PlayableSfxSettings : ScriptableObject
{
    [SerializeField] private AudioClip[] clipVariationsForThisSfx;
    [SerializeField] private Vector2 volumeRange = new Vector2(0.9f, 1f);
    [SerializeField] private Vector2 pitchRange = new Vector2(0.94f, 1.06f);
    [SerializeField, Range(0f, 1f)] private float spatialBlend;
    [SerializeField] private float minDistance = 1f;
    [SerializeField] private float maxDistance = 15f;

    public float SpatialBlend => spatialBlend;
    public float MinDistance => minDistance;
    public float MaxDistance => maxDistance;

    public AudioClip GetClipVariation()
    {
        return clipVariationsForThisSfx[Random.Range(0, clipVariationsForThisSfx.Length)];
    }

    public float GetRandomVolume()
    {
        return Random.Range(volumeRange.x, volumeRange.y);
    }

    public float GetRandomPitch()
    {
        return Random.Range(pitchRange.x, pitchRange.y);
    }
}