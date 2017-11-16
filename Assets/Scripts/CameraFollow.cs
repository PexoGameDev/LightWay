using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(0, 2)]
    public float smoothness;
    private Vector3 velocity = Vector3.zero;

    //Camera position bounds
    public Vector3 maxPosition;
    public Vector3 minPosition;

	void Update ()
    {
//Comment
        Vector3 newPosition = new Vector3(Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x), target.position.y, Mathf.Clamp(target.position.z, minPosition.z, maxPosition.z)) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothness);
	}
}
