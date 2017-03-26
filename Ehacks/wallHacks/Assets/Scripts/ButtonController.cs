using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject player;
	public Camera cam;

	// Use this for initialization
	void Start () {
		cam = player.GetComponent<Camera> ();
		Camera.main.enabled = true;
		cam.enabled = false;
	}
	
	public void OnClick() {
		cam = player.GetComponent<Camera>();

			Camera.main.enabled = false;
			cam.enabled = true;

	}
}
