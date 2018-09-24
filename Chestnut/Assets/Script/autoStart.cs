/*************************************************************************
 *
 *  dannyarnold.com 2017
 *  All Rights Reserved.
 * 
 * NOTICE:  All information contained herein is, and remains
 * the property of dannyarnold.com and its suppliers,
 * if any.  The intellectual and technical concepts contained
 * herein are proprietary to dannyarnold.com
 * and its suppliers and may be covered by U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from dannyarnold.com.
 *
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE.txt', which is part of this source code package.
 *
 */


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
