using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private PlayerInputHandler playerInput;

    public Transform follow;

    private Vector3 diff;

    void Start()
    {
        playerInput.SwapHappened += PlayerInput_SwapHappened;
        diff = transform.position - follow.position;
    }

    private void PlayerInput_SwapHappened(object sender, System.EventArgs e)
    {
        PlayerSwapEventArgs args = (PlayerSwapEventArgs)e;
        follow = args.GetPlayerTransform();
    }

    void Update()
    {
        transform.position = follow.position + diff;
    }
}
