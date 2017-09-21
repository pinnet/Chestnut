using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    protected static string _startingSquareName = "";
    private void OnMouseEnter()
    {
        Debug.Log(gameObject.name + " From " + _startingSquareName);
        
    }
    private void OnMouseDrag()
    {
        if (gameObject.name != _startingSquareName) _startingSquareName = gameObject.name;

    }
    private void OnMouseUp ()
    {
        _startingSquareName = "";

    }
}
