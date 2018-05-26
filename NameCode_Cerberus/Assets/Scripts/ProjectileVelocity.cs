using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileVelocity : MonoBehaviour {


	Rigidbody rb;
	public float bulletVelocity;
	public float lifetime;
	public float damage;
	private void Start(){

		if(bulletVelocity.Equals(0f))
		{
			bulletVelocity = 10f;
		}
		if (damage.Equals(0f))
		{
			damage = 1f;
		}
		rb = GetComponent<Rigidbody>();
		Invoke("AutoDestroy", lifetime);
	}


	private void FixedUpdate()
	{
		rb.velocity = transform.TransformDirection(Vector3.forward * bulletVelocity);
	}



	void OnTriggerEnter(Collider collider)
	{


		Hp_System target = collider.transform.GetComponent<Hp_System>();
		if (target != null)
		{

			target.TakeDamage(damage);
		}
	}
	void AutoDestroy()
	{
		Destroy(gameObject);
	}


}
