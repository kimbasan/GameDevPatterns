using DG.Tweening;
using UnityEngine;

public class MovementCommand : Command
{
    private Transform transformToMove;
    private Vector3 direction;

    public MovementCommand(Transform transformToMove, Vector3 direction)
    {
        this.transformToMove = transformToMove;
        this.direction = direction;
    }

    public override void Execute()
    {
        Move(transformToMove, direction);
    }

    public override void Undo()
    {
        Move(transformToMove, -direction);
    }

    public void Execute(TweenCallback callback)
    {
        Move(transformToMove, direction, callback);
    }

    public void Undo(TweenCallback callback)
    {
        Move(transformToMove, -direction, callback);
    }

    private void Move(Transform transform, Vector3 direction)
    {
        DOTween.Sequence()
        .SetEase(Ease.OutQuint)
        .Append(transform.DOMove(transform.position + direction, 0.5f));
    }

    private void Move(Transform transform, Vector3 direction, TweenCallback callback)
    {
        DOTween.Sequence()
        .SetEase(Ease.OutQuint)
        .Append(transform.DOMove(transform.position + direction, 0.5f))
        .AppendCallback(callback);
    }
}
