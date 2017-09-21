using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour {

    protected bool _playerIsWhite = false;
    //[SerializeField]
    

    public bool PlayerIsWhite
    { get { return _playerIsWhite; } }

    public void newWindow() {



    }

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
