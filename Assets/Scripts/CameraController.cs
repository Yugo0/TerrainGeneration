using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private float cameraZoomSpeed = 0.1f;
	[SerializeField]
	private float cameraSpeed = 100f;

	private Vector3 target = new Vector3(0, 0, 0);
	private float distance = 10f;
	private float magnitudeY = 89f;

	private Transform cameraTrans;
	private Camera cam;

	void Start()
	{
		cameraTrans = gameObject.GetComponent<Transform>();
		cam = gameObject.GetComponent<Camera>();
	}

	void Update()
	{
		float rotY = Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime;
		float rotX = Input.GetAxis("Vertical") * cameraSpeed * Time.deltaTime;

		float currentY = cameraTrans.localEulerAngles.x + (cameraTrans.localEulerAngles.x >= 270f ? -360f : 0f);

		if (currentY + rotX > magnitudeY)
		{
			rotX = magnitudeY - currentY;
		}
		else if (currentY + rotX < -magnitudeY)
		{
			rotX = -magnitudeY - currentY;
		}

		cameraTrans.transform.position = target;

		cameraTrans.transform.Rotate(new Vector3 (1, 0, 0), rotX);
		cameraTrans.transform.Rotate(new Vector3 (0, 1, 0), -rotY, Space.World);

		cameraTrans.transform.Translate(new Vector3(0, 0, -distance));

		cam.fieldOfView -= Input.mouseScrollDelta.y * cameraZoomSpeed;
	}
}
