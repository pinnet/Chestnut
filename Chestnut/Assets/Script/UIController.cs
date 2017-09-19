using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject console;

    protected bool _hidden = false;
    

    public void HideConsole(bool hide)
    {
        if (hide) {

            _hidden = false;
            console.SetActive(true);

        } else
        {
            _hidden = true;
            console.SetActive(false);
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
