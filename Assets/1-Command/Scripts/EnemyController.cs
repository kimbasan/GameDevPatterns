using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private List<EnemyMovement> enemies;

    private Vector3[] directions = new Vector3[] { Vector3.forward, Vector3.back, Vector3.left, Vector3.right, Vector3.zero};
    void Start()
    {
        player.PlayerActionHappened += Player_PlayerActionHappened;
    }

    private void Player_PlayerActionHappened(object sender, System.EventArgs e)
    {
        foreach (var enemy in enemies)
        {
            if (enemy.isActiveAndEnabled)
            {
                enemy.DoMove(GetRandomDirection());
            }
        }
    }

    private Vector3 GetRandomDirection()
    {
        return directions[Random.Range(0, directions.Length)];
    }

    private void OnDisable()
    {
        player.PlayerActionHappened -= Player_PlayerActionHappened;
    }
}
