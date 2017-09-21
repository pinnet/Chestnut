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

    private List<FENString> Moves = new List<FENString>();
    private const string _ranks = "abcdefgh";
    private bool _moved = false;
    private bool _startWhite = false;
    private bool _flipflop = true;
    private string _tag = "";
    // Use this for initialization

    void Start () {

        FENString fenString = new FENString("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2");
        if (fenString.isValid)
        {
            Moves.Add(fenString);
        }
        SetupBoard(fenString.Board);
    }

    private void SetupBoard(int[,] board)
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
                        piece.transform.rotation = Quaternion.identity;
                        _tag = "Empty";
                        break;
                }
                piece.tag = _tag;
                piece.transform.parent = square.transform;


                piece.transform.localPosition = Vector3.zero;
              
            }

            if (_startWhite) _flipflop = true;
            else _flipflop = false;
            _startWhite = !_startWhite;
        }
    }


    // Update is called once per frame
    void Update () {

        if (_moved)
        {


            



        }





    }
}
