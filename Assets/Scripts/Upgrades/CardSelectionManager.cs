using System;
using System.Collections.Generic;
using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private RandomCardSelector randomCardSelector;

    public event Action<List<UpgradeCard>> OnSelectionStarted;
    public event Action OnSelectionEnded;

    private void Awake()
    {
        waveManager.OnWaveCleared += HandleWaveCleared;
    }

    private void HandleWaveCleared()
    {
        List<UpgradeCard> cards = randomCardSelector.DrawCards();
        OnSelectionStarted?.Invoke(cards);
    }

    public void ChooseCard(UpgradeCard chosenCard)
    {
        chosenCard.Apply.Invoke();
        OnSelectionEnded?.Invoke();
    }

    private void OnDestroy()
    {
        waveManager.OnWaveCleared -= HandleWaveCleared;
    }
}
