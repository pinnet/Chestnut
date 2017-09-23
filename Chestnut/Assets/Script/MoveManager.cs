using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MoveManager : MonoBehaviour {

    protected List<FENString> Moves = new List<FENString>();
    protected FENString fenString = new FENString("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2");
    protected static bool _playerIsWhite = false;
    protected static int _move = 0;
    protected static int[,] _board;
    protected static Piece[,] _objBoard = new Piece[8, 8];
    protected static CapturedPieces captured;
    

    public int[,] FENBoard
    {
        get { return _board;  }
        set { _board = value; }
    }

    public void TogglePlayer() {

        PlayerIsWhite = !_playerIsWhite;

    }
    public bool PlayerIsWhite
    {
        get { return _playerIsWhite; }
        set
        {
            _playerIsWhite = value;

        }
    }
    public void Move(Square from, Square to)
    {
        if (from == to) return;
        Piece e = to.GetComponentInChildren<Piece>();
        if (e.GetType().ToString() == "Empty")
        {
            e.transform.parent = from.transform;
            e.transform.localPosition = Vector3.zero;
            
        }
        else
        {
            captured.add(e);
           
            GameObject ne = new GameObject("Empty");
            ne.AddComponent<Empty>();
            ne.transform.parent = from.transform;
        }

        Piece p = from.GetComponentInChildren<Piece>();
        p.transform.parent = to.transform;
        p.NumberOfMoves++;
        p.transform.localPosition = Vector3.zero;

        
        
        updateBoard();
    } 
    public virtual void SetupBoard(int[,] board)
    {
            throw new NotImplementedException();
    }
    
    public bool[,] BiuldCheckMatrix() {


        return new bool[8, 8];
    }
    private void updateBoard()
    {

        for (int a = 0; a < 8; a++)
            for (int b = 0; b < 8; b++) 
            {
                Piece p = _objBoard[a, b];
                _board = new int[8, 8];

                string typ = p.GetType().ToString();

                if (typ == "Empty") typ = "0";

                if (p.tag == "Black") typ = typ.ToLower();
                
                _board[a,b] = (typ == "0") ? 0 : ((int)char.Parse(typ[0].ToString()));
             

            }
        
        
    }
    private string BoardToFEN(Piece[,] board)
    {
        string res = "";

        for (int a = 0; a < 8; a++)
            for (int b = 0; b < 8; b++) ;

        return "";
    }
}
