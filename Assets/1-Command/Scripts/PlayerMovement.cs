using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public event EventHandler PlayerActionHappened;
    public event EventHandler GameOver;

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
    private PlayerInput inputs;

    private bool moving = false;
    private Vector3 direction;

    private void Start()
    {
        inputs.actions.Enable();

        moveUp.action.performed += MoveUp_performed;
        moveDown.action.performed += MoveDown_performed;
        moveLeft.action.performed += MoveLeft_performed;
        moveRight.action.performed += MoveRight_performed;

        skip.action.performed += SkipTurn_performed;
    }

    private void SkipTurn_performed(InputAction.CallbackContext obj)
    {
        PlayerActionHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Skip));
    }

    private void MoveRight_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.right);
        PlayerActionHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Right));
    }

    private void MoveLeft_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.left);
        PlayerActionHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Left));
    }

    private void MoveDown_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.back);
        PlayerActionHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Down));
    }

    private void MoveUp_performed(InputAction.CallbackContext obj)
    {
        Move(Vector3.forward);
        PlayerActionHappened?.Invoke(this, new PlayerActionEventArgs(ActionType.Up));
    }

    private void Move(Vector3 direction)
    {
        DisableInput();
        DOTween.Sequence()
            .SetEase(Ease.OutQuint)
            .Append(transform.DOMove(transform.position + direction, 0.5f))
            .AppendCallback(EnableInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            inputs.actions.Disable();
            GameOver?.Invoke(this, new GameOverEventArgs(false));
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            inputs.actions.Disable();
            GameOver?.Invoke(this, new GameOverEventArgs(true));
        }
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

public class GameOverEventArgs : EventArgs
{
    private bool win;

    public GameOverEventArgs(bool win)
    {
        this.win = win;
    }

    public bool IsWin() { return win; }
}

public enum ActionType
{
    Up, Down, Left, Right, Skip
}
