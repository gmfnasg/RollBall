using UnityEngine;
using System.Collections;

public class Server : MonoBehaviour {
	public GameObject ball = null;
	public GameObject board = null;
	public Vector3 pos = Vector3.zero;


	void Awake(){
		if (!GetComponent<NetworkView> ()) {
			gameObject.AddComponent<NetworkView>();
		}
		if (board != null) {
			pos = board.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Network.peerType == NetworkPeerType.Server) {
			LogText.AddLog("玩家數量:" + Network.connections.Length);
			Debug.Log ("玩家數量:" + Network.connections.Length);

			if((Input.touchCount>0 || Input.GetKeyDown(KeyCode.R)) &&  Network.connections.Length > 0){
				LogText.AddLog("重置球的位置");
				ball.transform.position = pos;
			}

			if (GetComponent<NetworkView> ()) {
				if (ball != null)
					GetComponent<NetworkView> ().RPC ("UpdateBall", RPCMode.Server, ball.transform.localRotation, ball.transform.position);
				if (board != null)
					GetComponent<NetworkView> ().RPC ("UpdateBoardQuaternion", RPCMode.Server, board.transform.localRotation);
			}
		} else if (Network.peerType == NetworkPeerType.Disconnected) {
			Debug.Log ("Server Start");
			Network.InitializeServer (99, 9997, !Network.HavePublicAddress ());
			MasterServer.RegisterHost ("CardBoard", "RollBall", "alpha 1.0");

			if (Network.peerType == NetworkPeerType.Server) {
				Debug.Log ("玩家數量:" + Network.connections.Length);
				LogText.AddLog("玩家數量:" + Network.connections.Length);
			}
		}
			


	}

	private void OnApplicationQuit()//當應用程式結束時
	{
		Network.Disconnect();//中斷客戶端連線
	}

	[RPC]
	void UpdateBoardQuaternion(Quaternion quaternion){
		
	}

	[RPC]
	void UpdateRotateBoard(Vector3 rotate){
		if (board != null) {
			board.transform.Rotate(rotate);
		}
	}

	[RPC]
	void UpdateBall(Quaternion quaternion, Vector3 position){

	}
}
