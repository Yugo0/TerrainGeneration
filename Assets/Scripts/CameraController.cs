using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private float cameraZoomSpeed = 0.1f;
	[SerializeField]
	private float cameraSpeed = 100f;

	private Vector3 target;
	private float distance = 10f;

	private Transform cameraTrans;

	void Start()
	{
		cameraTrans = gameObject.GetComponent<Transform>();
		target = new Vector3(0, 0, 0);
	}

	void Update()
	{
		float rotY = Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime;
		float rotX = Input.GetAxis("Vertical") * cameraSpeed * Time.deltaTime;

		cameraTrans.transform.position = target;

		cameraTrans.transform.Rotate(new Vector3 (1, 0, 0), rotX);
		cameraTrans.transform.Rotate(new Vector3 (0, 1, 0), -rotY, Space.World);

		distance -= Input.mouseScrollDelta.y * cameraZoomSpeed;
		cameraTrans.transform.Translate(new Vector3(0, 0, -distance));
	}
}
