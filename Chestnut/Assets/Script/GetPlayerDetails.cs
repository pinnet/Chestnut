using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerDetails : MonoBehaviour {

    Player player;
	// Use this for initialization
	void Start () {
        Player player = GameObject.FindObjectOfType<Player>();

        if (player)
        {
            GetComponent<Text>().text += " " + player.FirstName; ;


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
