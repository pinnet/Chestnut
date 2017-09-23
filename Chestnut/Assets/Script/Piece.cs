using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    
    protected bool[,] _checkMatrix = new bool[8, 8];
    protected static int[,] _board;
    

    public bool IsWhite
    {
        get { return checkColor(); }
        
    }
    public bool[,] CheckMatrix
    {
        get { return _checkMatrix; }
        set { _checkMatrix = value; }
    }
    public int[,] Board
    {
        get { return _board; }
        set { _board = value; }
    }
  
    protected int _numberOfMoves = 0;
    protected const string ranks = "abcdefgh"; 
    public bool[,] MoveMatrix
    { get { return BuildMoveMatrix(); } }

    public bool[,] BuildPieceMatrix() {
        bool[,] _pieceMatrix = new bool[8, 8];
        
        for (int r = 0; r < 8; r++)
            for (int f = 0; f < 8; f++)
            {
                _pieceMatrix[r, f] = (_board[r, f] == 0);
            }
        return _pieceMatrix;
    }

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

