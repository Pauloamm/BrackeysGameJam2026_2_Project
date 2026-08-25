using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [Header("Input Action References")]
    [SerializeField] private InputActionAsset gameplayInputMapRef;
    [SerializeField] private InputActionReference moveActionRef;
    [SerializeField] private InputActionReference mousePositionActionRef;
    [SerializeField] private InputActionReference confirmPlacementActionRef;
    [SerializeField] private InputActionReference cancelPlacementActionRef;
    [SerializeField] private InputActionReference selectCannonActionRef;
    [SerializeField] private InputActionReference selectShotgunActionRef;
    [SerializeField] private InputActionReference selectPylonActionRef;
    [SerializeField] private InputActionReference selectAegisActionRef;

    private Vector2 moveInput;
    public Vector2 MoveInput => moveInput;

    private Vector2 mousePosition;
    public Vector2 MousePosition => mousePosition;

    public event Action<Vector2> MoveInputChanged;
    public event Action ConfirmPlacementPressed;
    public event Action CancelPlacementPressed;
    public event Action SelectCannonPressed;
    public event Action SelectShotgunPressed;
    public event Action SelectPylonPressed;
    public event Action SelectAegisPressed;

    private void Awake()
    {
        gameplayInputMapRef.Enable();

        moveActionRef.action.performed += OnMovePerformed;
        moveActionRef.action.canceled += OnMoveCanceled;

        mousePositionActionRef.action.performed += OnMousePositionPerformed;

        confirmPlacementActionRef.action.started += OnConfirmPlacementStarted;
        cancelPlacementActionRef.action.started += OnCancelPlacementStarted;

        selectCannonActionRef.action.started += OnSelectCannonStarted;
        selectShotgunActionRef.action.started += OnSelectShotgunStarted;
        selectPylonActionRef.action.started += OnSelectPylonStarted;
        selectAegisActionRef.action.started += OnSelectAegisStarted;
    }

    private void OnDestroy()
    {
        moveActionRef.action.performed -= OnMovePerformed;
        moveActionRef.action.canceled -= OnMoveCanceled;

        mousePositionActionRef.action.performed -= OnMousePositionPerformed;

        confirmPlacementActionRef.action.started -= OnConfirmPlacementStarted;
        cancelPlacementActionRef.action.started -= OnCancelPlacementStarted;

        selectCannonActionRef.action.started -= OnSelectCannonStarted;
        selectShotgunActionRef.action.started -= OnSelectShotgunStarted;
        selectPylonActionRef.action.started -= OnSelectPylonStarted;
        selectAegisActionRef.action.started -= OnSelectAegisStarted;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        MoveInputChanged?.Invoke(moveInput);
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
        MoveInputChanged?.Invoke(moveInput);
    }

    private void OnMousePositionPerformed(InputAction.CallbackContext ctx)
    {
        mousePosition = ctx.ReadValue<Vector2>();
    }

    private void OnConfirmPlacementStarted(InputAction.CallbackContext ctx)
    {
        ConfirmPlacementPressed?.Invoke();
    }

    private void OnCancelPlacementStarted(InputAction.CallbackContext ctx)
    {
        CancelPlacementPressed?.Invoke();
    }

    private void OnSelectCannonStarted(InputAction.CallbackContext ctx)
    {
        SelectCannonPressed?.Invoke();
    }

    private void OnSelectShotgunStarted(InputAction.CallbackContext ctx)
    {
        SelectShotgunPressed?.Invoke();
    }

    private void OnSelectPylonStarted(InputAction.CallbackContext ctx)
    {
        SelectPylonPressed?.Invoke();
    }

    private void OnSelectAegisStarted(InputAction.CallbackContext ctx)
    {
        SelectAegisPressed?.Invoke();
    }
}