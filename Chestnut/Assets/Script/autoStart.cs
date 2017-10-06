using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;


public class autoStart : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern string GetName();
    private GameObject player;
    private string Firstname = "Unknown";
    // Use this for initialization
    void Start () {
        
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                Firstname = GetName();
                
                
                
            }
            else if (Application.platform == RuntimePlatform.LinuxPlayer)
            {
                //GetComponent<NetworkLobbyManager>().StartServer();
            }


        player = new GameObject(Firstname);
        player.AddComponent<Player>().FirstName = Firstname;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
