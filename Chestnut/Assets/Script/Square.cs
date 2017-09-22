using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MoveManager {
    protected static Square _startSquare;
    protected static bool _dragOn = false;
    protected static Square _endSquare;
    protected static Piece _selectedPiece;
    protected static bool isValid = false;


    public Piece SelectedPiece {
        get { return _selectedPiece; }
        set { _selectedPiece = value; }
    }

    private void OnMouseEnter()
    {
        if (_startSquare != null) {

            _endSquare = this;

        }
      if(_dragOn)
        {
            if (!SelectedPiece) return;
            SelectedPiece.Board = FENBoard;
            isValid = SelectedPiece.isValidMove(name);
            Quad q = GetComponentInChildren<Quad>();
            if (isValid)
            {
                q.Hilight(HiliteColor.green);
            }
            else {

                q.Hilight(HiliteColor.red);
                //SelectedPiece = null;
            }
        }
    }
    private void OnMouseExit()
    {
            Quad q = GetComponentInChildren<Quad>();
            q.Hilight(HiliteColor.none);
    }
    private void OnMouseDrag()
    {
        if (this != _startSquare) _startSquare = this;
       
        _dragOn = true;
    }
    private void OnMouseUp ()
    {
        if (isValid)
        {
            Move(_startSquare, _endSquare);
            isValid = false;
        }

        Quad q = gameObject.GetComponentInChildren<Quad>();
        q.Hilight(HiliteColor.none);

        _selectedPiece = null;
        _dragOn = false;
        _startSquare = null;
    }

   
}
