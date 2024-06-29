using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private InputHandler _playerInputHandler;
    [SerializeField] private CommandManagerView _commandsDebugView;
    [SerializeField] private float _movementDuration;

    private CommandManager _commandManager = new CommandManager();

    private void OnEnable()
    {
        _playerInputHandler.OnMovement.AddListener(OnMovementHandler);
        _playerInputHandler.OnUndo.AddListener(OnUndoHandler);
        _playerInputHandler.OnRedo.AddListener(OnRedoHandler);

        if (_commandsDebugView)
        {
            _commandsDebugView.SetOwner(_commandManager);
        }
    }
    private void OnDisable()
    {
        _playerInputHandler.OnMovement.RemoveListener(OnMovementHandler);
        _playerInputHandler.OnUndo.RemoveListener(OnUndoHandler);
        _playerInputHandler.OnRedo.RemoveListener(OnRedoHandler);
    }

    public override void Move(Vector3 movement)
    {
        base.Move(movement);
        _commandManager.DoCommand(new MoveCommand(transform, movement, _movementDuration));
    }
    private void UndoMove()
    {
        _commandManager.UndoCommand();
    }
    private void RedoMove()
    {
        _commandManager.RedoCommand();
    }
    private void OnMovementHandler(Vector3 movement)
    {
        Move(movement);
    }
    private void OnUndoHandler()
    {
        UndoMove();
    }
    private void OnRedoHandler()
    {
        RedoMove();
    }
}
