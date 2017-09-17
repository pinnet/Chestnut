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


    private List<FENString> Moves = new List<FENString>();

    private bool _moved = false;
    private int Turn = 0;


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

            for (int f = 0; f < 8; f ++) {


               switch ((char)board[r, f])
               {
                    case 'K':
                        Instantiate(whiteKing,new Vector3(f * 6,0,r *6), Quaternion.identity);
                    break;
                    case 'Q':
                        Instantiate(whiteQueen, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'B':
                        Instantiate(whiteBishop, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'N':
                        Instantiate(whiteKnight, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'R':
                        Instantiate(whiteRook, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'P':
                        Instantiate(whitePawn, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'k':
                        Instantiate(blackKing, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'q':
                        Instantiate(blackQueen, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'b':
                        Instantiate(blackBishop, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'n':
                        Instantiate(blackKnight, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'r':
                        Instantiate(blackRook, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                    case 'p':
                        Instantiate(blackPawn, new Vector3(f * 6, 0, r * 6), Quaternion.identity);
                        break;
                }
             }


        }
    }


    // Update is called once per frame
    void Update () {

        if (_moved)
        {


            



        }





    }
}
