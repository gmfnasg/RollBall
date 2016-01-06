using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemoteBall : MonoBehaviour {
	public void UpdateBall(Quaternion quaternion, Vector3 position){
		if (quaternion == null || position == null)
			return;
		
		transform.localRotation = quaternion;
		transform.position = position;
		LogText.AddLog("Do UpdateBall(quaternion:"+quaternion+", position:"+position+") \r\n");
	}
}
