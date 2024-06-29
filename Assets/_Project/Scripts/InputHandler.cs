using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public UnityEvent<Vector3> OnMovement;
    public UnityEvent OnUndo;
    public UnityEvent OnRedo;

    public void OnMovementActionHandler(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        OnMovement?.Invoke(context.ReadValue<Vector2>());
    }
    public void OnUndoActionHandler(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        OnUndo?.Invoke();
    }
    public void OnRedoActionHandler(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        OnRedo?.Invoke();
    }
}
