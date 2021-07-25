using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushController : MonoBehaviour
{
	[SerializeField]
	private float brushMagnitude = 0.1f;
	[SerializeField]
	private float brushSpeed = 10f;

	private float timer = 0f;

	private Camera cam;

	void Start()
	{
		cam = gameObject.GetComponent<Camera>();
	}

	void Update()
	{
		
	}

	void FixedUpdate()
	{
		if (Input.GetMouseButton(0))
		{
			handleInput(1);
		}
		else if (Input.GetMouseButton(1))
		{
			handleInput(-1);
		}
		else
		{
			timer = 0f;
		}
	}

	private void handleInput(float setValue)
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 3))
		{
			timer += brushSpeed * Time.fixedDeltaTime;
			if (timer > 1f)
			{
				timer = 0f;
				hit.transform.gameObject.GetComponent<Terrain>().drawTerrain(hit.point, brushMagnitude, setValue);
			}
		}
	}
}
