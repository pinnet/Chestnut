﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerConnector : MonoBehaviour {
    [SerializeField]
    Text text;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}