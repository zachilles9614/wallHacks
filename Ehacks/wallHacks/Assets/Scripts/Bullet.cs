using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int damageAmount = 10;

	void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health>();
		if (health  != null)
		{
			health.TakeDamage(damageAmount);
		}

		Destroy(gameObject);
	}

	public void changeDamage(int damage) {
		damageAmount = damage;
	}
}