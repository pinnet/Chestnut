using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;


public class autoStart : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void Hello();

    // Use this for initialization
    void Start () {
        
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                Hello();
            }
            else if (Application.platform == RuntimePlatform.LinuxPlayer)
            {
                GetComponent<NetworkLobbyManager>().StartServer();
            }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
