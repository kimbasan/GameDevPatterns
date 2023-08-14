using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DestroyerCollider"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
