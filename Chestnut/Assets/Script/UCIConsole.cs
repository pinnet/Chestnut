using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UCIConsole : MonoBehaviour {
    
    [SerializeField]
    Text con;

    protected string _stdin ="";
    protected string _stdout = "";


    public string STDIN
    {
        set { _stdin = value; Refresh(); }
    }
    [SerializeField]
    public string STDOUT {
        get { string ret = _stdout + "\n"; _stdout = ""; return ret; }

    }

	// Use this for initialization
	void Start () {

        _stdout = "Chestnut Version 1.0";
        
        con.text += STDOUT;	
	}
	
	void Refresh() {

        _stdout += _stdin;
        _stdin = "";
        con.text += STDOUT;
    }
}
