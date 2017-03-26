using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;

public class NetworkManager : MonoBehaviour {

	public static NetworkManager singleton;

		public bool isAtStartup = true;

		NetworkClient myClient;

		void Update () 
		{
			if (isAtStartup)
			{
				if (Input.GetKeyDown(KeyCode.S))
				{
					SetupServer();
				}

				if (Input.GetKeyDown(KeyCode.C))
				{
					SetupClient();
				}

				if (Input.GetKeyDown(KeyCode.B))
				{
					SetupServer();
					SetupLocalClient();
				}
			}
		}

		void OnGUI()
		{
//			if (isAtStartup)
//			{
//				GUI.Label(new Rect(2, 10, 150, 100), "Press S for server");     
//				GUI.Label(new Rect(2, 30, 150, 100), "Press B for both");       
//				GUI.Label(new Rect(2, 50, 150, 100), "Press C for client");
//			}
		}   


	public void SetupServer() {
		NetworkServer.Listen(4444);
		isAtStartup = false;
	}	

	public void SetupClient()
	{
		myClient = new NetworkClient ();
		myClient.RegisterHandler (MsgType.Connect, OnConnected);
	}

	public void SetupLocalClient() {

		myClient = ClientScene.ConnectLocalServer ();
		myClient.RegisterHandler (MsgType.Connect, OnConnected);
		isAtStartup = false;

	}

	public void OnConnected(NetworkMessage netMsg) {
		Debug.Log ("Connected to server");
	}
}

