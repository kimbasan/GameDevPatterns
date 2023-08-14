using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public void DoMove(Vector3 direction)
    {
        if (gameObject.activeSelf)
        {
            DOTween.Sequence()
            .SetEase(Ease.OutQuint)
            .Append(transform.DOMove(transform.position + direction, 0.5f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestroyerCollider"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
