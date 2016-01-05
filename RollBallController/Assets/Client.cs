using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Client : MonoBehaviour {
	bool onConnect = false;

	void Awake(){
		if (!gameObject.GetComponent<NetworkView> ()) {
			gameObject.AddComponent<NetworkView>();
		}

		MasterServer.ClearHostList();
		MasterServer.RequestHostList ("CardBoard");
	}

	void Update () {
		if (Network.peerType == NetworkPeerType.Disconnected) {
			LogText.AddLog("斷線中");
			ConnectServer ();
		}
		if (Network.peerType == NetworkPeerType.Client) {
			LogText.AddLog("與SERVER保持連線中1");
		}
		if (Network.peerType == NetworkPeerType.Connecting) {
			LogText.AddLog("與SERVER保持連線中2");
		}

		LogText.AddLog("touchCount:("+Input.touchCount+")");

		if (Input.touchCount == 1) {
			onConnect = false;
			ConnectServer ();
		}

		if (Input.touchCount ==2) {
			MasterServer.ClearHostList();
			MasterServer.RequestHostList ("CardBoard");
		}
	}

	void ConnectServer(){
		if (onConnect)
			return;

		HostData[] datas = MasterServer.PollHostList ();
		LogText.AddLog("datas " + datas );
		if (datas.Length > 0) {
			LogText.AddLog("datas.Length " + datas.Length );

			HostData data = datas [0];
			LogText.AddLog("ip:(" + data.ip +") port("+data.port+")");

			if (data != null) {
				Network.Connect (data);
				onConnect = true;

				LogText.AddLog("Connect to server!");
			}
		}
	}

	private void OnApplicationQuit()//當應用程式結束時
	{
		Network.Disconnect();//中斷客戶端連線
	}
}
