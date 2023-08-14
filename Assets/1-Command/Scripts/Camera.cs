using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform follow;

    private Vector3 diff;

    void Start()
    {
        diff = transform.position - follow.position;
    }

    void Update()
    {
        transform.position = follow.position + diff;
    }
}
