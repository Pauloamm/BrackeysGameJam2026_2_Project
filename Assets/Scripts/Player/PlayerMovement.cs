using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private float moveSpeed = 6f; // default 6f

    [SerializeField] private Rigidbody2D rb;
    private Vector2 facingScale = Vector2.one;

    private bool isMoving;
    public event Action<bool> OnMovementStateChanged;

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = inputReader.MoveInput;

        if (moveInput != Vector2.zero)
        {
            rb.linearVelocity = moveInput.normalized * moveSpeed;
            UpdateFacing(moveInput.x);
            SetIsMoving(true);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            SetIsMoving(false);
        }
    }

    private void UpdateFacing(float direction)
    {
        if (direction == 0f) return;

        facingScale.x = Mathf.Sign(direction);
        transform.localScale = facingScale;
    }

    private void SetIsMoving(bool value)
    {
        if (isMoving == value) return;

        isMoving = value;
        OnMovementStateChanged?.Invoke(isMoving);
    }
}
