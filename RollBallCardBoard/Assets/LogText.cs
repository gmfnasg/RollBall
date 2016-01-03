using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogText : MonoBehaviour {
	public static Text logText = null;

	public static void AddLog (string log){
		if (logText == null) {
			GameObject.Find("LogText").GetComponent<Text>();
		}
		if (logText != null) {
			logText.text += log;
		} else {
			Debug.Log(log);
		}
	}
}
