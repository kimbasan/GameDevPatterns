using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public event EventHandler InputHappened;
    public event EventHandler UndoHappened;
    public event EventHandler MoveHappened;
    public event EventHandler SwapHappened;

    public Queue<MovementCommand> movements = new Queue<MovementCommand>();

    [Header("Player")]
    [SerializeField]
    private MovementActor player;
    [Header("Enemies")]
    [SerializeField]
    private EnemyController enemyController;

    [Header("Input references")]
    [SerializeField]
    private InputActionReference moveUp;
    [SerializeField]
    private InputActionReference moveDown;
    [SerializeField]
    private InputActionReference moveLeft;
    [SerializeField]
    private InputActionReference moveRight;
    [SerializeField]
    private InputActionReference skip;
    [SerializeField]
    private InputActionReference undo;
    [SerializeField]
    private InputActionReference swap;

    [SerializeField]
    private PlayerInput inputs;

    private void Start()
    {
        inputs.actions.Enable();

        moveUp.action.performed += MoveUp_performed;
        moveDown.action.performed += MoveDown_performed;
        moveLeft.action.performed += MoveLeft_performed;
        moveRight.action.performed += MoveRight_performed;
        undo.action.performed += UndoAction_performed;
        swap.action.performed += SwapAction_performed;
        skip.action.performed += SkipTurn_performed;
    }

    private void SwapAction_performed(InputAction.CallbackContext obj)
    {
        var enemies = enemyController.GetEnemies();
        var actor = enemies[UnityEngine.Random.Range(0, enemies.Count)];
        enemies.Remove(actor);
        enemies.Add(player);
        player = actor;
        enemyController.SetEnemies(enemies);

        InputHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Swap));
        SwapHappened?.Invoke(this, new PlayerSwapEventArgs(player.transform));
    }

    private void UndoAction_performed(InputAction.CallbackContext obj)
    {
        DisableInput();
        MovementCommand undoCommand;
        if (movements.TryDequeue(out undoCommand))
        {
            undoCommand.Undo(EnableInput);
        } else
        {
            EnableInput();
        }
        UndoHappened?.Invoke(this, EventArgs.Empty);
        InputHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Undo));
    }

    private void SkipTurn_performed(InputAction.CallbackContext obj)
    {
        InputHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Skip));
    }

    private void MoveRight_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.right);
        InputHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Right));
    }

    private void MoveLeft_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.left);
        InputHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Left));
    }

    private void MoveDown_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.back);
        InputHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Down));
    }

    private void MoveUp_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.forward);
        InputHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Up));
    }

    private void Move(Vector3 direction)
    {
        DisableInput();
        var movementCommand = new MovementCommand(player.transform, direction);
        movements.Enqueue(movementCommand);
        player.Move(movementCommand, EnableInput);

        MoveHappened?.Invoke(this, EventArgs.Empty);
    }

    private void DisableInput()
    {
        inputs.actions.Disable();
    }

    private void EnableInput()
    {
        inputs.actions.Enable();
    }

    private void OnDisable()
    {
        moveUp.action.performed -= MoveUp_performed;
        moveDown.action.performed -= MoveDown_performed;
        moveLeft.action.performed -= MoveLeft_performed;
        moveRight.action.performed -= MoveRight_performed;
        undo.action.performed -= UndoAction_performed;
        swap.action.performed -= SwapAction_performed;
        skip.action.performed -= SkipTurn_performed;
    }
}
public class PlayerActionEventArgs : EventArgs
{
    private ActionType actionType;

    public PlayerActionEventArgs(ActionType actionType)
    {
        this.actionType = actionType;
    }

    public ActionType GetActionType() { return actionType; }
}

public class PlayerSwapEventArgs : EventArgs
{
    private Transform newPlayerTransform;

    public PlayerSwapEventArgs(Transform newPlayerTransform)
    {
        this.newPlayerTransform = newPlayerTransform;
    }

    public Transform GetPlayerTransform()
    {
        return newPlayerTransform;
    }
}

public enum ActionType
{
    Up, Down, Left, Right, Skip,
    Undo, Swap
}
