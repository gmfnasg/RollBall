using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Client : MonoBehaviour {
	Text LogText;

	void Awake(){
		if (!gameObject.GetComponent<NetworkView> ()) {
			gameObject.AddComponent<NetworkView>();
		}
	}

	void Update () {
		if (Network.peerType == NetworkPeerType.Disconnected) {
			Debug.Log("斷線中");
		}
		if (Network.peerType == NetworkPeerType.Client) {
			Debug.Log("與SERVER保持連線中1");
		}
		if (Network.peerType == NetworkPeerType.Connecting) {
			Debug.Log("與SERVER保持連線中2");
		}
		if (Network.peerType == NetworkPeerType.Disconnected)
			ConnectServer ();
	}

	void ConnectServer(){
		MasterServer.RequestHostList ("CardBoard");

		HostData[] datas = MasterServer.PollHostList ();
		
		if (datas.Length > 0) {
			HostData data = datas [0];
			if (data != null) {
				Network.Connect (data);

				if(LogText!=null)
					LogText.text += "Connect to server! \r\n";
			}
		}
	}
}
