// SimpleFollowCamera.cs
using UnityEngine;

public class SimpleFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -5);
    [SerializeField] private float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (!target) return;
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
