using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputHandler player;

    [SerializeField]
    private List<MovementActor> enemies;

    public List<MovementActor> GetEnemies()
    {
        return enemies;
    }

    public void SetEnemies(List<MovementActor> enemies)
    {
        this.enemies = enemies;
    }

    void Start()
    {
        player.MoveHappened += Player_PlayerActionHappened;
        player.UndoHappened += Player_UndoHappened;
    }

    private void Player_UndoHappened(object sender, System.EventArgs e)
    {
        foreach (var enemy in enemies)
        {
            if (enemy.isActiveAndEnabled)
            {
                enemy.UndoMove();
            }
        }
    }

    private void Player_PlayerActionHappened(object sender, System.EventArgs e)
    {
        foreach (var enemy in enemies)
        {
            if (enemy.isActiveAndEnabled)
            {
                enemy.DoMove();
            }
        }
    }

    private void OnDisable()
    {
        player.InputHappened -= Player_PlayerActionHappened;
    }
}
