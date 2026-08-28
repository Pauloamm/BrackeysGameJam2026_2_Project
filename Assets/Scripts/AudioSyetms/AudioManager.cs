using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSourcePrefab;
    [SerializeField] private int poolSize = 24;

    private Transform pooledSourcesContainer;
    private List<AudioSource> audioSourcePool;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        pooledSourcesContainer = new GameObject("Pooled Audio Sources").transform;
        pooledSourcesContainer.SetParent(transform);

        audioSourcePool = new List<AudioSource>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            AudioSource pooledSource = Instantiate(audioSourcePrefab, pooledSourcesContainer);
            audioSourcePool.Add(pooledSource);
        }
    }

    public void Play2DClip(PlayableSfxSettings sfxSettings)
    {
        AudioSource source = GetAvailableSource();
        source.spatialBlend = 0f;
        ApplySfxSettings(source, sfxSettings);
        source.Play();
    }

    public void Play3DClip(PlayableSfxSettings sfxSettings, Vector3 worldPosition)
    {
        AudioSource source = GetAvailableSource();
        source.transform.position = worldPosition;
        source.spatialBlend = sfxSettings.SpatialBlend;
        source.minDistance = sfxSettings.MinDistance;
        source.maxDistance = sfxSettings.MaxDistance;
        ApplySfxSettings(source, sfxSettings);
        source.Play();
    }

    private void ApplySfxSettings(AudioSource source, PlayableSfxSettings sfxSettings)
    {
        source.clip = sfxSettings.GetClipVariation();
        source.volume = sfxSettings.GetRandomVolume();
        source.pitch = sfxSettings.GetRandomPitch();
    }

    private AudioSource GetAvailableSource()
    {
        foreach (AudioSource source in audioSourcePool)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }

        return audioSourcePool[0];
    }
}