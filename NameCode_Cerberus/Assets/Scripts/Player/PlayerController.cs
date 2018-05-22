using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public GameObject body;
	float horizontal;
	float vertical;
	public float speed;
	public float gravity;
	Vector3 movementDirection;
	Vector3 rotationDirection;
	Vector3 mousePosition;
	Vector3 mouseDirection;
	CharacterController controller;


	void Start () {
		if(speed.Equals(0))
		{
			speed = 1;
		}
		controller = GetComponent<CharacterController>();
	}
	

	void Update () {
		
	}

	private void FixedUpdate()
	{
		//Get movement input value
		movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		movementDirection = transform.TransformDirection(movementDirection);
		movementDirection *= speed;
		movementDirection.y -= gravity * Time.deltaTime;

		//move
		controller.Move(movementDirection * Time.deltaTime);


		//rotation
		Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);

		float distance = (transform.position - Camera.main.transform.position).magnitude;

		mousePosition = mouseray.origin + mouseray.direction * distance;
		mouseDirection.Set(mousePosition.x, body.transform.position.y, mousePosition.z);
		body.transform.LookAt(mouseDirection);
	}

}