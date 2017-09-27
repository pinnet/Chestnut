using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    [SerializeField]
    GameObject whiteKing;
    [SerializeField]
    GameObject whiteQueen;
    [SerializeField]
    GameObject whiteBishop;
    [SerializeField]
    GameObject whiteKnight;
    [SerializeField]
    GameObject whiteRook;
    [SerializeField]
    GameObject whitePawn;

    [SerializeField]
    GameObject blackKing;
    [SerializeField]
    GameObject blackQueen;
    [SerializeField]
    GameObject blackBishop;
    [SerializeField]
    GameObject blackKnight;
    [SerializeField]
    GameObject blackRook;
    [SerializeField]
    GameObject blackPawn;
    [SerializeField]
    GameObject whiteQuad;
    [SerializeField]
    GameObject blackQuad;
    [SerializeField]
    CapturedPieces yourPieces;


    public bool Upated = false;
    protected List<FENString> Moves = new List<FENString>();
    
    protected  bool _playerIsWhite = false;
    protected  bool[,] _positionMatrix = new bool[8, 8];
    protected  int _move = 0;
    protected  int[,] _board;
    protected  Piece[,] _objBoard = new Piece[8, 8];
    protected  CapturedPieces captured;

    private const string _ranks = "abcdefgh";
    
    private bool _startWhite = false;
    private bool _flipflop = true;
    private string _tag = "";
    private UCIConsole con;

   public int[,] Layout
    {
        get { return _board; }
    }

    public void TogglePlayer()
    {

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
    public bool[,] PositionMatrix
    {
        get { return _positionMatrix; }
        set { _positionMatrix = value; }
    }
    void Start () {

        con = GameObject.FindObjectOfType<UCIConsole>();
        con.STDIN = "Start Game <Board.cs>";


        FENString.ParseString("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2");
        captured = yourPieces;

        if (FENString.isValid)
        {
            _board = FENString.Layout;
            con.STDIN = ("FEN " + FENString.RawString);
           // Moves.Add(FENString);
            _positionMatrix = BuildPositionMatrix();
        }
        SetupBoard(_board);
        Upated = true;
    }

    public bool[,] BuildPositionMatrix()
    {
        
        bool[,] positionMatrix = new bool[8, 8];

        for (int r = 0; r < 8; r++)
            for (int f = 0; f < 8; f++)
            {
                positionMatrix[r, f] = (_board[r, f] == 0);
            }
        return positionMatrix;
    }

    public void SetupBoard(int[,] board)
    {
       

        for (int r = 0; r < 8; r++) {

            GameObject square,quad;

            for (int f = 0; f < 8; f ++) {

                square = new GameObject(_ranks[r] + (f + 1).ToString());
                square.transform.position = new Vector3(6f * f, 0f, 6f * r);
                square.transform.parent = transform;
                square.AddComponent<Square>();
                BoxCollider bc = square.AddComponent<BoxCollider>();
                bc.size = new Vector3(6f, 1f, 6f);
                bc.isTrigger = true;

                square.tag = "Square";

                if (_flipflop)
                {
                    quad = Instantiate(whiteQuad, Vector3.zero, Quaternion.Euler(90f, 0f, 0f));
                    quad.transform.parent = square.transform;
                    quad.transform.localPosition = Vector3.zero;
                }
                else
                {
                    quad = Instantiate(blackQuad, Vector3.zero, Quaternion.Euler(90f, 0f, 0f));
                    quad.transform.parent = square.transform;
                    quad.transform.localPosition = Vector3.zero;
                }
                _flipflop = !_flipflop;

                GameObject piece;
                switch ((char)board[r, f])
               {
                    case 'K':
                        piece = Instantiate(whiteKing,Vector3.zero, Quaternion.identity);
                        piece.name = "White King";
                        _tag = "White";
                        
                        break;
                    case 'Q':
                        piece = Instantiate(whiteQueen, Vector3.zero, Quaternion.identity);
                        piece.name = "White Queen";
                        _tag = "White";
                        break;
                    case 'B':
                        piece = Instantiate(whiteBishop, Vector3.zero, Quaternion.identity);
                        piece.name = "White Bishop";
                        _tag = "White";
                        break;
                    case 'N':
                        piece = Instantiate(whiteKnight,Vector3.zero, Quaternion.identity);
                        piece.name = "White Knight";
                        _tag = "White";
                        break;
                    case 'R':
                        piece = Instantiate(whiteRook,Vector3.zero, Quaternion.identity);
                        piece.name = "White Rook";
                        _tag = "White";
                        break;
                    case 'P':
                        piece = Instantiate(whitePawn,Vector3.zero, Quaternion.identity);
                        piece.name = "White Pawn";
                        _tag = "White";
                        break;
                    case 'k':
                        piece = Instantiate(blackKing,Vector3.zero, Quaternion.identity);
                        piece.name = "Black King";
                        _tag = "Black";
                        break;
                    case 'q':
                        piece = Instantiate(blackQueen,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Queen";
                        _tag = "Black";
                        break;
                    case 'b':
                        piece = Instantiate(blackBishop,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Bishop";
                        _tag = "Black";
                        break;
                    case 'n':
                        piece = Instantiate(blackKnight,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Knight";
                        _tag = "Black";
                        break;
                    case 'r':
                        piece = Instantiate(blackRook,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Rook";
                        _tag = "Black";
                        break;
                    case 'p':
                        piece = Instantiate(blackPawn,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Pawn";
                        _tag = "Black";
                        break;
                    default :
                        piece = new GameObject("Empty");
                        piece.AddComponent<Empty>();
                        piece.transform.rotation = Quaternion.identity;
                        _tag = "Empty";
                        break;
                }
                piece.tag = _tag;
                piece.transform.parent = square.transform;
                piece.transform.localPosition = Vector3.zero;
                _objBoard[r, f] = piece.GetComponent<Piece>();
            }

            if (_startWhite) _flipflop = true;
            else _flipflop = false;
            _startWhite = !_startWhite;
        }
        BuildPositionMatrix();
    }
    public void Move(Square from, Square to)
    {
        if (from == to) return;

        Piece selectedPiece = from.GetComponentInChildren<Piece>();
        Piece enmey = to.GetComponentInChildren<Piece>();

        if (enmey.tag == selectedPiece.tag) return;

        if (enmey.GetType().ToString() == "Empty")
        {
            enmey.transform.parent = from.transform;
            enmey.transform.localPosition = Vector3.zero;

        }
        else
        {

            captured.add(enmey);

            GameObject newEmpty = new GameObject("Empty");
            newEmpty.AddComponent<Empty>();
            newEmpty.transform.parent = from.transform;

        }

        Piece p = from.GetComponentInChildren<Piece>();
        p.transform.parent = to.transform;
        p.NumberOfMoves++;
        p.transform.localPosition = Vector3.zero;
        UpdateBoard();
        Upated = true;
    }
  
    public bool[,] BuildCheckMatrix()
    {


        return new bool[8, 8];
    }
    private void UpdateBoard()
    {
        _board = new int[8, 8];
        for (int a = 0; a < 8; a++)
            for (int b = 0; b < 8; b++)
            {
                Piece p = _objBoard[a, b];
                

                string typ = p.GetType().ToString();

                if (typ == "Empty") typ = "0";

                if (p.tag == "Black") typ = typ.ToLower();
                char o = typ[0];

                _board[a, b] = (typ == "0") ? 0 : (char.Parse(o.ToString()));
            }
        _positionMatrix = BuildPositionMatrix();

    }
    private string BoardToFEN(Piece[,] board)
    {

        for (int a = 0; a < 8; a++)
            for (int b = 0; b < 8; b++) ;

        return "";
    }

}
