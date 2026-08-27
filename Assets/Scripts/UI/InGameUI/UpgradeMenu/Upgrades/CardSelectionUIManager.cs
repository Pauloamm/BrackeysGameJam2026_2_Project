using System.Collections.Generic;
using UnityEngine;

public class CardSelectionUIManager : MonoBehaviour
{
    [SerializeField] private CardSelectionManager cardSelectionManager;
    [SerializeField] private GameObject selectionScreenRoot;
    [SerializeField] private UpgradeCardVisualUI cardVisualPrefab;
    [SerializeField] private Transform cardContainer;

    private readonly List<UpgradeCardVisualUI> spawnedCards = new List<UpgradeCardVisualUI>();

    private void Awake()
    {
        cardSelectionManager.OnSelectionStarted += HandleSelectionStarted;
        cardSelectionManager.OnSelectionEnded += HandleSelectionEnded;
        selectionScreenRoot.SetActive(false);
    }

    private void HandleSelectionStarted(List<UpgradeCard> cards)
    {
        ClearSpawnedCards();

        foreach (UpgradeCard card in cards)
        {
            UpgradeCardVisualUI cardVisual = Instantiate(cardVisualPrefab, cardContainer);
            cardVisual.Bind(card);
            cardVisual.OnChosen += HandleCardChosen;
            spawnedCards.Add(cardVisual);
        }

        selectionScreenRoot.SetActive(true);
    }

    private void HandleCardChosen(UpgradeCard chosenCard)
    {
        cardSelectionManager.ChooseCard(chosenCard);
    }

    private void HandleSelectionEnded()
    {
        selectionScreenRoot.SetActive(false);
        ClearSpawnedCards();
    }

    private void ClearSpawnedCards()
    {
        foreach (UpgradeCardVisualUI cardVisual in spawnedCards)
        {
            cardVisual.OnChosen -= HandleCardChosen;
            Destroy(cardVisual.gameObject);
        }

        spawnedCards.Clear();
    }

    private void OnDestroy()
    {
        cardSelectionManager.OnSelectionStarted -= HandleSelectionStarted;
        cardSelectionManager.OnSelectionEnded -= HandleSelectionEnded;
    }
}
