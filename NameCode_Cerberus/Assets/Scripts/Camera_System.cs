using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_System : MonoBehaviour {

	public Camera Camera;
	public Transform target;

	public Vector3 offset;

	public float smoothSpeed = 0.100F;

	private void LateUpdate()
	{
		Camera.transform.position = target.position + offset;
	}
}
