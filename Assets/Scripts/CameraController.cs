using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float dampTime = 0.5f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	private new Camera camera;

	private void Awake()
	{
		camera = GetComponent<Camera>();
	}

	private void Update()
	{
		if (target)
		{
			var point = camera.WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.5f, target.position.z));
			var delta = new Vector3(target.position.x, target.position.y + 0.5f, target.position.z) - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			var destination = transform.position + delta;

			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}