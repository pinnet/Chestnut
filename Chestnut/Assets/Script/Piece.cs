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


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    
    protected bool[,] _checkMatrix = new bool[8, 8];
    
    protected static int[,] _layout;
    protected static bool[,] _pieceMatrix;
    protected static Board _board;
    public bool IsWhite
    {
        get { return checkColor(); }
        
    }
     
    protected int _numberOfMoves = 0;
    protected const string ranks = "abcdefgh"; 
    public bool[,] MoveMatrix
    { get { return BuildMoveMatrix(); } }

   

    public virtual bool[,] BuildMoveMatrix()
    {
        throw new NotImplementedException();
    }

    public bool isValidMove(string from)
    {

        if (from == transform.parent.name) return true;

        Position p = GetPosition(from);

        return MoveMatrix[p.Rank,p.File];

        
    }
    private void Start()
    {
        _board = GetComponentInParent<Board>();
    }
    private void Update()
    {
        if (_pieceMatrix != _board.PositionMatrix)
        {

            _pieceMatrix = _board.PositionMatrix;
        }
    }
    private bool checkColor() {

        return (tag == "White");
    }
    public Position CurrentPosition
    {
        get { return GetCurrentPosition(); }
    }

    public int NumberOfMoves
    {
        get { return _numberOfMoves; }
        set { _numberOfMoves = value; }
    }

    private Position GetCurrentPosition()
    {
        string n = gameObject.transform.parent.name;
       
        return GetPosition(n);
    }
    private Position GetPosition(string n)
    {
        
        int r = 0, f = 0;

        r = ranks.IndexOf(n[0]);
        f = Int32.Parse(n[1].ToString()) - 1;
        return new Position(r, f);
    }
}
public struct Position
{
    int _r, _f;
   
    public Position(int r, int f) : this()
    {
        this._r = r;
        this._f = f;
    }

    public int Rank {
        get { return _r; }

    }
    public int File
    {
        get { return _f; }

    }
}

