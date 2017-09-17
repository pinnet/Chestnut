using System;
using UnityEngine;

public class FENString {

    const string CN = "KQkq-";
    const string SAN = "KQBNRPkqbnrp-";
    const string MN = "ABCDEFGHabcdefgh12345678x=()0O";
    const string EN = "abcdefgh12345678-";

    protected int FENWORDS = 13;
    protected string _FEN = "";
    protected string _ENP = "";
    protected int _HMC = 0;
    protected int _FMN = 0;
    protected bool _isWhiteMove = false;
    protected bool _isValid = false;
    protected bool _wccqs = false;
    protected bool _wccks = false;
    protected bool _bccqs = false;
    protected bool _bccks = false;

    public FENString(string FEN) {

        _isValid = validateFEN(FEN);
        _FEN = FEN;

    }
    public string EnPesantMove
    {
        get
        {
            return _ENP;
        }
    }
    public string RawString
    {
        get
        {
            return _FEN;
        }
    }
    public bool WhiteCanCastleQueenSide
    {
        get
        {
            return _wccqs;
        }
    }
    public bool WhiteCanCastleKingsSide
    {
        get
        {
            return _wccks;
        }
    }
    public bool BlackCanCastleQueenSide
    {
        get
        {
            return _bccqs;
        }
    }
    public bool BlackCanCastleKingsSide
    {
        get
        {
            return _bccks;
        }
    }
    public bool isWhiteMove
    {

        get
        {
            return _isWhiteMove;
        }

    }
    public bool isValid
    {

        get
        {
            return _isValid;
        }

    }

    public int HalfMoveClock
    {
        get
        {
            return _HMC;
        }
    }
    public int FullMoveNumber
    {
        get
        {
            return _FMN;
        }
    }

    public bool validateFEN(string str) {

        String[] fenWords = str.Split(' ');

        if (fenWords.Length != FENWORDS) return false;

        for (int i = 0; i < 8; i++)
        {
            if (!checkSquares(fenWords[i])) return false;
        }

        if (fenWords[(int)FEN.Player] != "w" && fenWords[(int)FEN.Player] != "b") return false;

        _isWhiteMove = (fenWords[(int)FEN.Player] == "w") ? true : false;
       
        if (!checkCastle(fenWords[(int)FEN.Castle])) return false;

        if (!checkEnPesant(fenWords[(int)FEN.Enpeasant])) return false;

        if (!checkHalfMoveClock(fenWords[(int)FEN.HalfMove])) return false;

        if (!checkFullMoveNumber(fenWords[(int)FEN.FullMove])) return false;

        return true;

    }

    private bool checkHalfMoveClock(string halfMoveClock)
    {

        if (!Int32.TryParse(halfMoveClock, out _HMC)) return false;
        return true;
    }

    private bool checkFullMoveNumber(string fullMoveNumber)
    {
        if (!Int32.TryParse(fullMoveNumber, out _FMN)) return false;
        return true;
    }
    private bool checkEnPesant(string enPesant)
    {

        if (!EN.Contains(enPesant)) return false;
        if (enPesant.Contains("-")) return true;
        if (enPesant.Length != 2) return false;
        _ENP = enPesant;
        return true;
    }

    private bool checkCastle(string castle)
    {

        if (!CN.Contains(castle)) return false;
        if (castle.Contains("-")) return true;
        for (int i = 0; i < castle.Length; i++)
        { 
            switch (castle[i])
            {
                case 'K':
                    _wccks = true;
                    break;
                case 'Q':
                    _wccqs = true;
                    break;
                case 'k':
                    _bccks = true;
                    break;
                case 'q':
                    _bccqs = true;
                    break;
            default:
                    break;
            }
        }
        return true;
    }

    private bool checkSquares(string rank)
    {
        int Squares = 0;
        char buff;
        
        for (int i = 0; i < rank.Length; i++) {

            buff = rank[i];

            if (Char.IsNumber(buff))
            {
                Squares += ((int)buff - 48);
            }
            else {


                if (!SAN.Contains(buff + "")) return false;
                Squares++;

            }
        }
        return (Squares == 8);
    }

    public enum FEN
    {
        Rank1,Rank2,Rank3,Rank4,Rank5,Rank6,Rank7,Rank8,
        Player,Castle,Enpeasant,HalfMove,FullMove
    }
    
}
