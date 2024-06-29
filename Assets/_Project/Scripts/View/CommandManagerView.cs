using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManagerView : MonoBehaviour
{
    [SerializeField] private List<TMPro.TMP_Text> _undoCommandTexts = new List<TMPro.TMP_Text>();
    [SerializeField] private List<TMPro.TMP_Text> _redoCommandTexts = new List<TMPro.TMP_Text>();

    private CommandManager _owner = null;

    private void FixedUpdate()
    {
        if(_owner == null) return;

        UpdateCommandTexts();
    }
    public void SetOwner(CommandManager owner)
    {
        _owner = owner;
    }
    private void UpdateCommandTexts()
    {
        for (int i = 0; i < 10; i++)
        {
            _undoCommandTexts[i].text = i < _owner.UndoList.Count ? _owner.UndoList[i].ToString() : "";
        }

        for (int i = 0; i < 10; i++)
        {
            _redoCommandTexts[i].text = i < _owner.RedoList.Count ? _owner.RedoList[i].ToString() : "";
        }
    }
}
