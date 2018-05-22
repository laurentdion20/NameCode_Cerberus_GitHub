using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {


	public GameObject projectile;


	void Update () {

		if (Input.GetButtonDown("Fire1"))
		{

			//Debug.Log("AsShoot");
			Shoot();
		}
	}


	void Shoot()
	{
		Instantiate(projectile, transform.position, transform.rotation);
	}
}
