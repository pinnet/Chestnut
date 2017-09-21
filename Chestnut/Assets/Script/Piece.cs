using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    protected int _numberOfMoves = 0 ;


    public bool isValidMove(string from)
    {

        return false;
    }
    public string CurrentPosition
    {
        get { return GetCurrentPosition(); }
    }

    public int NumberOfMoves
    {
        get { return _numberOfMoves; }
    }

    private void Start()
    {

    }
    
    private string GetCurrentPosition()
    {

        return gameObject.transform.parent.name;
    }
}


