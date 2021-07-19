using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushController : MonoBehaviour
{
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
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 20))
			{
				Debug.Log(hit.point);
			}
		}
	}
}
