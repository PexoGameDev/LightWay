using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(0, 2)]
    public float smoothness = 0.25f;
    private Vector3 velocity = Vector3.zero;

	void Update ()
    {
        Vector3 newPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothness);
	}
}
