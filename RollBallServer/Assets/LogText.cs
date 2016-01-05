using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogText : MonoBehaviour {
	public static Text logText = null;

	public static void AddLog (string log){
		if (logText == null) {
			logText = GameObject.Find("LogText").GetComponent<Text>();
		}
		if (logText != null) {
			logText.text += log + "\r\n";
		} else {
			Debug.Log(log);
		}

		if (logText.text.Length > 300)
			logText.text = logText.text.Remove (0, 200);
	}

	
	void Update(){
		if (Input.touchCount == 5 || Input.GetKeyDown(KeyCode.C))
			logText.text = "";
	}
}
