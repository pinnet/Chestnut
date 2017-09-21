using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    protected static string _startSquareName = "";
    protected static bool _dragOn = false;
    protected static string _endSquareName = "";

    private void OnMouseEnter()
    {
        if (_startSquareName != "") {

            _endSquareName = _startSquareName + " " + name;

        }
        if (_dragOn)
        {
            Quad q = GetComponentInChildren<Quad>();

            q.Hilight(HiliteColor.green);
        }
    }
    private void OnMouseDrag()
    {
        if (gameObject.name != _startSquareName) _startSquareName = gameObject.name;
        _dragOn = true;
    }
    private void OnMouseUp ()
    {
        _dragOn = false;
        Quad q = GetComponentInChildren<Quad>();
        q.Hilight(HiliteColor.green);
        _startSquareName = "";
        Debug.Log(_endSquareName);
    }
}
