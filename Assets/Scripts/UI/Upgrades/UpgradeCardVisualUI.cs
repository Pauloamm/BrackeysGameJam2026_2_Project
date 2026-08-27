using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeCardVisualUI : MonoBehaviour
{
    [SerializeField] private TMP_Text sourceLabelText;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Button selectButton;

    private UpgradeCard boundCard;

    public event Action<UpgradeCard> OnChosen;

    private void Awake()
    {
        selectButton.onClick.AddListener(HandleClicked);
    }

    public void Bind(UpgradeCard card)
    {
        boundCard = card;
        sourceLabelText.text = card.SourceLabel;
        titleText.text = card.Title;
        descriptionText.text = card.Description;
    }

    private void HandleClicked()
    {
        OnChosen?.Invoke(boundCard);
    }

    private void OnDestroy()
    {
        selectButton.onClick.RemoveListener(HandleClicked);
    }
}