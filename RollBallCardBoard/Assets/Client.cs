using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Client : MonoBehaviour {
	bool connectServer = false;
	Text LogText;

	void Start () {
		if (!gameObject.GetComponent<NetworkView> ()) {
			gameObject.AddComponent<NetworkView>();
		}
	}

	void Update () {
		if (!connectServer)
			ConnectServer ();
	}

	void ConnectServer(){
		MasterServer.RequestHostList ("CardBoard");
		HostData[] datas = MasterServer.PollHostList ();
		
		if (datas.Length > 0) {
			HostData data = datas [0];
			if (data != null) {
				Network.Connect (data);
				connectServer = true;

				if(LogText!=null)
					LogText.text += "Connect to server! \r\n";
			}
		}
	}
}
