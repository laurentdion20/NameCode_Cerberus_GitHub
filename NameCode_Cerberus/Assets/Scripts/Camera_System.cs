using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_System : MonoBehaviour {

	public Camera Camera;
	public Transform target;
	public Vector3 offset;
	public Vector3 targetPosition;
	public float smoothSpeed = 0.100f;
	public float panSpeed = 20f;
	public float screenBorder = 15f;
	public int scrollspeed = 3;
	public int maxHeight = 100;
	public int minHeight = 20;

	public bool is_Follow = false;
	bool transitionOnUnits = false;
	bool onPoints;

	private void Update()
	{

		if (transitionOnUnits)
		{
			TransitionToUnits();
		}

		if (onPoints)
		{
			is_Follow = true;
			Follow();
		}

		if (Input.GetMouseButtonDown(1))
		{
			target.transform.GetComponent<PlayerController>().enabled = false;
			target.transform.GetComponentInChildren<PlayerAttack>().enabled = false;
			is_Follow = false;
			onPoints = false;
		}

	


		if (is_Follow == false && transitionOnUnits == false)
		{

			Vector3 position = Camera.transform.position;

			if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - screenBorder)
			{
				position.z += panSpeed * Time.deltaTime;
			}
			if (Input.GetKey("s") || Input.mousePosition.y >= Screen.height - screenBorder)
			{
				position.z -= panSpeed * Time.deltaTime;
			}
			if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - screenBorder)
			{
				position.x += panSpeed * Time.deltaTime;
			}
			if (Input.GetKey("a") || Input.mousePosition.x >= Screen.width - screenBorder)
			{
				position.x -= panSpeed * Time.deltaTime;
			}
			if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView <= (maxHeight - scrollspeed))
			{
				Camera.main.fieldOfView += scrollspeed;
			}
			if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView >= (minHeight + scrollspeed))
			{
				Camera.main.fieldOfView -= scrollspeed; ;
			}

			Camera.transform.position = position;
		}
		

		if (Input.GetMouseButtonDown(0))
		{
				//Raycasting
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit, 10000f))
				{

					if (hit.transform.tag == "Player")
					{
						if (target != null)
						{
						target.transform.GetComponent<PlayerController>().enabled = false;
						target.transform.GetComponentInChildren<PlayerAttack>().enabled = false;
						}

					target = hit.transform;
					target.transform.position = hit.transform.position;
					transitionOnUnits = true;
					onPoints = false;
					}
					
				}
				
		}
	}

	void TransitionToUnits()
	{
		float distance = Vector3.Distance(Camera.transform.position, target.transform.position + offset);
		Camera.transform.position = Vector3.Lerp(Camera.transform.position, target.position + offset, 0.05f);
		//Debug.Log("Transition");

		

		if (distance <= 0.5f)
		{

			Camera.transform.position = target.position + offset;
			onPoints = true;
			transitionOnUnits = false;
			Debug.Log("Distance <= 0.1f");
		}
	}

	void Follow()
	{
		target.transform.GetComponent<PlayerController>().enabled = true;
		target.transform.GetComponentInChildren<PlayerAttack>().enabled = true;
		//targetPosition = target.transform.position;
		Camera.transform.position = target.position + offset;
	}


}
