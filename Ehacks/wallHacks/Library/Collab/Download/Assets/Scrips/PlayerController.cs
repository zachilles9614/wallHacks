using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
    

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		var horiz = Input.GetAxis("Horizontal") * Time.deltaTime * 15.0f;
		var vert = Input.GetAxis("Vertical") * Time.deltaTime * 15.0f;
		var rotationV = Input.GetAxis ("RotationV");
		var rotationH = Input.GetAxis ("RotationH");
	//transform.Rotate(0, rotation, 0);
		float angle = Mathf.Atan2 (rotationH, rotationV) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (new Vector3 (0, angle, 0));
		transform.Translate(horiz, 0, 0);

		transform.Translate(0, 0, vert);

		//if (Input.GetKeyDown(KeyCode.Space))
		if (Input.GetAxisRaw("Fire1")!=0)
		{
			CmdFire();
		}
	}

	[Command]
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;


		NetworkServer.Spawn(bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 3.0f);        
	}

	public override void OnStartLocalPlayer ()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	public PlayerController getPlayer() {
		return this;
	}
}