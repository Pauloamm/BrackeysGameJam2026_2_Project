using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [Header("Input Action References")]
    [SerializeField] private InputActionAsset gameplayInputMapRef;
    [SerializeField] private InputActionReference moveActionRef;

    private Vector2 moveInput;
    public Vector2 MoveInput => moveInput;

    public event Action<Vector2> MoveInputChanged;

    private void Awake()
    {
        gameplayInputMapRef.Enable();

        moveActionRef.action.performed += OnMovePerformed;
        moveActionRef.action.canceled += OnMoveCanceled;
    }

    private void OnDestroy()
    {
        moveActionRef.action.performed -= OnMovePerformed;
        moveActionRef.action.canceled -= OnMoveCanceled;
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
}
