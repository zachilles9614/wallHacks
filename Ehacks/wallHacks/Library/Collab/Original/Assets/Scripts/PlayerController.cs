using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;

public class PlayerController : NetworkBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public GameObject player;
//	var ButtonCooler : float = 0.5 ; // Half a second before reset
//	var ButtonCount : int = 0;

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

//		transform.position.y = 0;
//		transform.rotation.y = 0.0f;
//		transform.rotation.z = 0.0f;
//

//		if ( Input.GetKeyDown( KeyCode.LeftArrow) ){
//
//				if ( ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/){
//				transform.LookAt(player.GetComponent);
//				}else{
//					ButtonCooler = 0.5 ; 
//					ButtonCount += 1 ;
//				}
//			}
//
//			if ( ButtonCooler > 0 )
//			{
//
//				ButtonCooler -= 1 * Time.deltaTime ;
//
//			}else{
//				ButtonCount = 0 ;
//			}

		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 230.0f;
		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 10.0f;

	
		transform.Rotate (0, x, 0);
		transform.Translate (0, 0, z);


		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
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
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 60;


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