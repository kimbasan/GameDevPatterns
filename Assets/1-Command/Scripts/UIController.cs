using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerMovement playerMovements;
    [Header("Action Images")]
    [SerializeField] private Image up;
    [SerializeField] private Image down;
    [SerializeField] private Image left;
    [SerializeField] private Image right;
    [SerializeField] private Image skip;

    [Header("Result Panels")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject finishedPanel;

    private void Start()
    {
        playerMovements.PlayerActionHappened += PlayerMovements_PlayerActionHappened;
        playerMovements.GameOver += PlayerMovements_GameOver;
    }

    private void PlayerMovements_GameOver(object sender, System.EventArgs e)
    {
        GameOverEventArgs args = (GameOverEventArgs)e;
        if (args.IsWin())
        {
            finishedPanel.SetActive(true);
        } else
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void PlayerMovements_PlayerActionHappened(object sender, System.EventArgs e)
    {
        PlayerActionEventArgs args = (PlayerActionEventArgs)e;
        switch(args.GetActionType()) {
            case ActionType.Up: FlashImage(up); break;
            case ActionType.Down: FlashImage(down); break;
            case ActionType.Left: FlashImage(left); break;
            case ActionType.Right: FlashImage(right); break;
            case ActionType.Skip: FlashImage(skip); break;
        }
        
    }

    private void FlashImage(Image image)
    {
        DOTween.Sequence()
            .Append(image.DOColor(Color.green, 0.3f))
            .Append(image.DOColor(Color.white, 0.3f));
    }

    private void OnDisable()
    {
        playerMovements.PlayerActionHappened -= PlayerMovements_PlayerActionHappened;
        playerMovements.GameOver -= PlayerMovements_GameOver;
    }
}
