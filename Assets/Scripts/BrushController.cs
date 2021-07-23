using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushController : MonoBehaviour
{
	[SerializeField]
	private float brushMagnitude = 0.1f;

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
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 20))
			{
				hit.transform.gameObject.GetComponent<Terrain>().drawTerrain(hit.point, brushMagnitude, 1);
			}
		}
		else if (Input.GetMouseButton(1))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 20))
			{
				hit.transform.gameObject.GetComponent<Terrain>().drawTerrain(hit.point, brushMagnitude, -1);
			}
		}
	}
}
