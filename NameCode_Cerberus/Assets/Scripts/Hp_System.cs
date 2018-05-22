using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_System : MonoBehaviour {


	public float hp;


	private void Start()
	{
		if (hp.Equals(0))
		{
			hp = 5;
		}
	}

	private void Update()
	{
		if(hp <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void TakeDamage(float damage)
	{
		hp -= damage;
	}
}
