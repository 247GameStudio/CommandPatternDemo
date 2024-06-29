using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandManager
{
    /// <summary>
    /// This is a visualization access.
    /// </summary>
    public List<ICommand> UndoList => _undoList.ToList();
    /// <summary>
    /// This is a visualization access.
    /// </summary>
    public List<ICommand> RedoList => _redoList.ToList();

    private List<ICommand> _undoList = new List<ICommand>();
    private List<ICommand> _redoList = new List<ICommand>();

    private int _commandLimit = 10;
    public CommandManager(int commandLimit = 10)
    {
        _commandLimit = commandLimit;
    }

    public void DoCommand(ICommand command)
    {
        command.Do();
        _undoList.Add(command);
        _redoList.Clear();

        if(_undoList.Count > _commandLimit)
        {
            _undoList.RemoveAt(0);
        }
    }

    public void UndoCommand()
    {
        if (_undoList.Count > 0)
        {
            ICommand activeCommand = _undoList[_undoList.Count-1];
            _undoList.RemoveAt(_undoList.Count - 1);

            _redoList.Add(activeCommand);
            activeCommand.Undo();
        }
    }

    public void RedoCommand()
    {
        if (_redoList.Count > 0)
        {
            ICommand activeCommand = _redoList[_redoList.Count-1];
            _redoList.RemoveAt(_redoList.Count - 1);

            _undoList.Add(activeCommand);
            activeCommand.Do();
        }
    }
}
