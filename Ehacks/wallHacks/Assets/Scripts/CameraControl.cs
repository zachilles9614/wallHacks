using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	private Vector3 offset;
	void start() {
		offset = transform.position;
	}
	void LateUpdate() {
		transform.position = player.transform.position + offset;
	}
		
}
