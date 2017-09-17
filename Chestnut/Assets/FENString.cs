using System;
using UnityEngine;

public class FENString {

    const string CN  = "KQkq-";
    const string SAN = "KQBNRPkqbnrp-";
    const string MN  = "ABCDEFGHabcdefgh12345678x=()0O";
    const string EN  = "abcdefgh12345678-";
    const int FENWORDS = 6;

    protected int[,] _board = new int[8, 8];
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
    protected bool _BlackKing = false;
    protected bool _WhiteKing = false;

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
    public int[,] Board
    {

        get
        {
            return _board;
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

        String[] boardRanks = fenWords[(int)FEN.Ranks].Split('/');

        for (int i = 0; i < 8; i++)
        {
            if (!CheckSquares(boardRanks[i], i)) return false;
        }

        if (!_WhiteKing || !_BlackKing) return false;

        if (fenWords[(int)FEN.Player] != "w" && fenWords[(int)FEN.Player] != "b") return false;

        _isWhiteMove = (fenWords[(int)FEN.Player] == "w") ? true : false;
       
        if (!CheckCastle(fenWords[(int)FEN.Castle])) return false;

        if (!CheckEnPesant(fenWords[(int)FEN.Enpeasant])) return false;

        if (!CheckHalfMoveClock(fenWords[(int)FEN.HalfMove])) return false;

        if (!CheckFullMoveNumber(fenWords[(int)FEN.FullMove])) return false;

        return true;

    }

    private bool CheckHalfMoveClock(string halfMoveClock)
    {

        if (!Int32.TryParse(halfMoveClock, out _HMC)) return false;
        return true;
    }

    private bool CheckFullMoveNumber(string fullMoveNumber)
    {
        if (!Int32.TryParse(fullMoveNumber, out _FMN)) return false;
        return true;
    }
    private bool CheckEnPesant(string enPesant)
    {
        if (enPesant.Contains("-")) return true;
        for (int i = 0; i < enPesant.Length; i++)
        {
            if (!EN.Contains(enPesant[i].ToString())) return false;
        }
        if (enPesant.Length != 2) return false;
        _ENP = enPesant;
        return true;
    }

    private bool CheckCastle(string castle)
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

    private bool CheckSquares(string rankString,int rankNumber)
    {
        int numberOfEmpty,squaresCount = 0;

        int rank = 7 - rankNumber;
        char buff;
        
        for (int i = 0; i < rankString.Length; i++) {

            buff = rankString[i];



            if (Char.IsNumber(buff))
            {
                numberOfEmpty = Int32.Parse(buff.ToString());

                for (int f = squaresCount; f < numberOfEmpty; f++) { 
                    _board[rank,f] = 0; }

                squaresCount += numberOfEmpty;
            }
            else {
                 if (!SAN.Contains(buff.ToString())) return false;

                if (buff == 'K')
                {
                    if (_WhiteKing) return false;
                    _WhiteKing = true;
                }
                if (buff == 'k')
                {
                    if (_BlackKing) return false;
                    _BlackKing = true;
                }

                _board[rank, squaresCount] = buff;
                squaresCount++;
                    
            }
        }
        return (squaresCount == 8);
    }

    public enum FEN : int
    {
        Ranks,Player,Castle,Enpeasant,HalfMove,FullMove
    }
    
}
