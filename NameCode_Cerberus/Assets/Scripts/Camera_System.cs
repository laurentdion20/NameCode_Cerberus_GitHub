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
	public int scrollspeed = 2;
	public int maxHeight = 100;
	public int minHeight = 20;

	public bool is_Follow = false;

	/*private void LateUpdate()
	{
		Camera.transform.position = target.position + offset;
	}*/

	private void Update()
	{

		
		Vector3 position = Camera.transform.position;

		if (Input.GetKey("w")|| Input.mousePosition.y>= Screen.height - screenBorder)
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
		if(Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView <= (maxHeight-scrollspeed))
		{
			Camera.main.fieldOfView += scrollspeed;
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView >= (minHeight+scrollspeed))
		{
			Camera.main.fieldOfView -= scrollspeed; ;
		}

		Camera.transform.position = position;
	}



	void Follow()
	{
		targetPosition = target.transform.position;
	}
}
