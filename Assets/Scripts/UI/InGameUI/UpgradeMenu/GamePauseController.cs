using System.Collections.Generic;
using UnityEngine;

public class GamePauseController : MonoBehaviour
{
    [SerializeField] private CardSelectionManager cardSelectionManager;

    private void Awake()
    {
        cardSelectionManager.OnSelectionStarted += HandleSelectionStarted;
        cardSelectionManager.OnSelectionEnded += HandleSelectionEnded;
    }

    private void HandleSelectionStarted(List<UpgradeCard> cards)
    {
        Time.timeScale = 0f;
    }

    private void HandleSelectionEnded()
    {
        Time.timeScale = 1f;
    }

    private void OnDestroy()
    {
        cardSelectionManager.OnSelectionStarted -= HandleSelectionStarted;
        cardSelectionManager.OnSelectionEnded -= HandleSelectionEnded;
    }
}
