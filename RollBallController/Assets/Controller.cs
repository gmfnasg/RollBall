using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	void Awake(){
		if (!gameObject.GetComponent<NetworkView> ()) {
			gameObject.AddComponent<NetworkView>();
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 rot = new Vector3 (Input.acceleration.y, -Input.acceleration.x, 0);
		if (Network.peerType == NetworkPeerType.Client) {
			if (GetComponent<NetworkView> ()) {
				GetComponent<NetworkView> ().RPC("UpdateRotateBoard", RPCMode.Server, rot);
			}
		}

		transform.Rotate (rot);
	}

	[RPC]
	void UpdateRotateBoard(Vector3 rotate){
	}
}
