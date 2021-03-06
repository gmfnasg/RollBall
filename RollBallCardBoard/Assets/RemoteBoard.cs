﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemoteBoard : MonoBehaviour {
	public void UpdateBoardQuaternion(Quaternion quaternion){
		if (quaternion == null)
			return;

		transform.localRotation = quaternion;
		LogText.AddLog("Do UpdateRotateBoard("+quaternion+") \r\n");
	}
}