using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour {
    private bool AreYouShure = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {

        if (!AreYouShure)
        {
            gameObject.GetComponentInChildren<Text>().text = "Are You Shure ?";
            AreYouShure = true;
        }
        else {

            transform.parent.GetComponent<PauseManager>().Quit();
             }
    }
}
