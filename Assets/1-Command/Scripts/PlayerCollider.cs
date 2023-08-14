using System;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public event EventHandler GameOver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver?.Invoke(this, new GameOverEventArgs(false));
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            GameOver?.Invoke(this, new GameOverEventArgs(true));
        }
    }
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

