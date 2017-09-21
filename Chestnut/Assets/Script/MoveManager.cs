using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour {
    [SerializeField]
    protected bool _playerIsWhite = false;
    [SerializeField]
    protected int _move = 0;
    [SerializeField]
    protected HorizontalInput camraGimble;

    public int Move
    {
        get { return _move; }

    }
    public void TogglePlayer() {

        PlayerIsWhite = !_playerIsWhite;

    }
    public bool PlayerIsWhite
    {
        get { return _playerIsWhite; }
        set
        {
            camraGimble.RotateToWhite(value);
            _playerIsWhite = value;

        }
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
