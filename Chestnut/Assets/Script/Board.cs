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

    // Use this for initialization

    void Start () {

        FENString fenString = new FENString("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1");
        if (fenString.isValid)
        {
            Moves.Add(fenString);
        }
        SetupBoard(fenString.Board);
    }

    private void SetupBoard(int[,] board)
    {
        
        for (int r = 0; r < 8; r++) {

            GameObject square;

            for (int f = 0; f < 8; f ++) {

                square = new GameObject(_ranks[r] + (f + 1).ToString());
                square.transform.position = new Vector3(6f * f, 0f, 6f * r);
                square.transform.parent = transform;

                if (_flipflop)
                {
                   Instantiate(whiteQuad, Vector3.zero, Quaternion.Euler(90f, 0f, 0f)).transform.parent = square.transform;
                    
                }
                else
                {
                    Instantiate(blackQuad, Vector3.zero, Quaternion.Euler(90f, 0f, 0f)).transform.parent = square.transform; 
                   
                }
                _flipflop = !_flipflop;
                
                GameObject piece;
                switch ((char)board[r, f])
               {
                    case 'K':
                        piece = Instantiate(whiteKing,Vector3.zero, Quaternion.identity);
                        piece.name = "White King";
                        break;
                    case 'Q':
                        piece = Instantiate(whiteQueen, Vector3.zero, Quaternion.identity);
                        piece.name = "White Queen";
                        break;
                    case 'B':
                        piece = Instantiate(whiteBishop, Vector3.zero, Quaternion.identity);
                        piece.name = "White Bishop";
                        break;
                    case 'N':
                        piece = Instantiate(whiteKnight,Vector3.zero, Quaternion.identity);
                        piece.name = "White Knight";
                        break;
                    case 'R':
                        piece = Instantiate(whiteRook,Vector3.zero, Quaternion.identity);
                        piece.name = "White Rook";
                        break;
                    case 'P':
                        piece = Instantiate(whitePawn,Vector3.zero, Quaternion.identity);
                        piece.name = "White Pawn";
                        break;
                    case 'k':
                        piece = Instantiate(blackKing,Vector3.zero, Quaternion.identity);
                        piece.name = "Black King";
                        break;
                    case 'q':
                        piece = Instantiate(blackQueen,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Queen";
                        break;
                    case 'b':
                        piece = Instantiate(blackBishop,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Bishop";
                        break;
                    case 'n':
                        piece = Instantiate(blackKnight,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Knight";
                        break;
                    case 'r':
                        piece = Instantiate(blackRook,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Rook";
                        break;
                    case 'p':
                        piece = Instantiate(blackPawn,Vector3.zero, Quaternion.identity);
                        piece.name = "Black Pawn";
                        break;
                    default :
                        piece = new GameObject("Empty");
                        piece.transform.rotation = Quaternion.identity;
                        break;
                }
                
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
