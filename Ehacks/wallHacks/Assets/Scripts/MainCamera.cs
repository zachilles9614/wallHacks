using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeView() {
		this.enabled = !this.enabled;
	}
}
