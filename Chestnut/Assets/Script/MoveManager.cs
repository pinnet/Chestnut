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

        Piece p = from.GetComponentInChildren<Piece>();
        p.transform.parent = to.transform;
        p.NumberOfMoves++;
        p.transform.localPosition = Vector3.zero;
    }

}
