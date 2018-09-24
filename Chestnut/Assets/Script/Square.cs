/*************************************************************************
 *
 *  dannyarnold.com 2017
 *  All Rights Reserved.
 * 
 * NOTICE:  All information contained herein is, and remains
 * the property of dannyarnold.com and its suppliers,
 * if any.  The intellectual and technical concepts contained
 * herein are proprietary to dannyarnold.com
 * and its suppliers and may be covered by U.S. and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from dannyarnold.com.
 *
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE.txt', which is part of this source code package.
 *
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour{
    protected static Square _startSquare;
    protected static bool _dragOn = false;
    protected static Square _endSquare;
    protected static Piece _selectedPiece;
    protected static bool isValid = false;
    protected static bool[,] Positions;

    public Piece SelectedPiece {

        get { return _selectedPiece;}
        set { _selectedPiece = value; }

    }
    
    private void OnMouseEnter()
    {
        if (_startSquare != null) {

            _endSquare = this;

        }
      if(_dragOn)
        {
            if (!_selectedPiece) return;
            // transform.parent.GetComponent<Board>().PositionMatrix = Positions;
            //SelectedPiece.CheckMatrix = BuildCheckMatrix();
            isValid = _selectedPiece.isValidMove(name);
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
            Board Parent = transform.parent.GetComponent<Board>();
            Parent.Move(_startSquare, _endSquare); 
            isValid = false;
        }

        Quad q = gameObject.GetComponentInChildren<Quad>();
        q.Hilight(HiliteColor.none);

        _selectedPiece = null;
        _dragOn = false;
        _startSquare = null;
    }

   
}
