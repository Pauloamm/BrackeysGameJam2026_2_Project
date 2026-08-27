using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionMappingManager : MonoBehaviour
{
    private const string GameplayMapName = "Keyboard";

    [SerializeField] private CardSelectionManager cardSelectionManager;
    [SerializeField] private InputActionAsset inputActions;

    private InputActionMap gameplayMap;

    private void Awake()
    {
        gameplayMap = inputActions.FindActionMap(GameplayMapName);

        cardSelectionManager.OnSelectionStarted += HandleSelectionStarted;
        cardSelectionManager.OnSelectionEnded += HandleSelectionEnded;
    }

    private void HandleSelectionStarted(List<UpgradeCard> cards)
    {
        gameplayMap.Disable();
    }

    private void HandleSelectionEnded()
    {
        gameplayMap.Enable();
    }

    private void OnDestroy()
    {
        cardSelectionManager.OnSelectionStarted -= HandleSelectionStarted;
        cardSelectionManager.OnSelectionEnded -= HandleSelectionEnded;
    }
}
