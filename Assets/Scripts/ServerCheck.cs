using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

public class ServerCheck : NetworkBehaviour {
	void Awake() {
		NetworkManager nm = GetComponent<NetworkManager>();

		if (IsHeadless()) {
			print("Headless mode detected");
			nm.StartServer();
		}
	}
		
	bool IsHeadless() {
		return SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null;
	}
}
