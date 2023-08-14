using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class MovementActor : MonoBehaviour
{
    private static Vector3[] Directions = new Vector3[] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right, Vector3.zero };

    Queue<MovementCommand> movementsBackward = new Queue<MovementCommand>();
    Stack<MovementCommand> movementsForward = new Stack<MovementCommand>();

    public void DoMove()
    {
        if (gameObject.activeSelf)
        {
            MovementCommand command;
            if (!movementsForward.TryPop(out command))
            {
                command = new MovementCommand(transform, GetRandomDirection());
            }
            command.Execute();
            movementsBackward.Enqueue(command);
        }
    }

    public void UndoMove()
    {
        if (gameObject.activeSelf)
        {
            MovementCommand undoMovement;
            if (movementsBackward.TryDequeue(out undoMovement))
            {
                undoMovement.Undo();
                movementsForward.Push(undoMovement);
            }
        }
    }
    public void Move(MovementCommand movement, TweenCallback callback)
    {
        movement.Execute(callback);
    }

    public void UndoMove(MovementCommand movement, TweenCallback callback)
    {
        movement.Undo(callback);
    }

    private Vector3 GetRandomDirection()
    {
        return Directions[Random.Range(0, Directions.Length)];
    }
}
