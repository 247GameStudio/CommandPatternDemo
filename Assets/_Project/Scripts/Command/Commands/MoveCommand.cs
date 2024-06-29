using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCommand : ICommand
{
    private Transform _target = null;
    private Vector3 _movement = Vector2.zero;
    private float _movementDuration = 1f;

    public MoveCommand(Transform target, Vector3 movement, float duration = 1f)
    {
        _target = target;
        _movement = movement;
        _movementDuration = duration;
    }

    public void Do()
    {
        Move(_movement);
    }

    public void Undo()
    {
        Move(-_movement);
    }

    private void Move(Vector3 movement)
    {
        if(_target == null)
        {
            Debug.LogError("Error: Can't execute MoveCommand. Target is null");
            return;
        }

        _target.DOMove(_target.position + movement, _movementDuration).SetEase(Ease.OutExpo);

        //Simple juicyness
        _target.DOScaleY(1.1f, _movementDuration).SetEase(Ease.OutElastic).OnComplete(() => _target.DOScaleY(1f, .05f).SetEase(Ease.OutExpo));
        _target.DOScaleX(.9f, _movementDuration).SetEase(Ease.OutElastic).OnComplete(() => _target.DOScaleY(1f, .05f).SetEase(Ease.OutExpo));
    }
}
