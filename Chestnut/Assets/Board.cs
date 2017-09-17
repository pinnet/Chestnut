using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    
    private List<FENString> Moves = new List<FENString>();

    private bool _moved = false;
    private int Turn = 0;


    // Use this for initialization

    void Start () {

        FENString fenString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w KQqk - 0 0");
        if (fenString.isValid)
        {
            Moves.Add(fenString);
        }
     
        Debug.Log("\n" + Moves.Count);
    }
	

	// Update is called once per frame
	void Update () {

        if (_moved)
        {


            



        }





    }
}
