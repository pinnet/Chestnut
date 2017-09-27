using System;
using UnityEngine;

public class FENString {

    const string CN  = "KQkq-";
    const string SAN = "KQBNRPkqbnrp-";
    const string MN  = "ABCDEFGHabcdefgh12345678x=()0O";
    const string EN  = "abcdefgh12345678-";
    const int FENWORDS = 6;

    protected static int[,] _board = new int[8, 8];
    protected static string _FEN = "";
    protected static string _ENP = "";
    protected static int _HMC = 0;
    protected static int _FMN = 0;
    protected static bool _isWhiteMove = false;
    protected static bool _isValid = false;
    protected static bool _wccqs = false;
    protected static bool _wccks = false;
    protected static bool _bccqs = false;
    protected static bool _bccks = false;
    protected static bool _BlackKing = false;
    protected static bool _WhiteKing = false;


    private static void ResetFEN() {

        _BlackKing = false;
        _WhiteKing = false;
        _isWhiteMove = false;
        _isValid = false;
        _wccqs = false;
        _wccks = false;
        _bccqs = false;
        _bccks = false;
        _FEN = "";
         _ENP = "";
        _HMC = 0;
        _FMN = 0;

}
    public static bool ParseString(string FEN)
    {
        ResetFEN();
        _isValid = validateFEN(FEN);
        return _isValid;
    }
    public static string EnPesantMove
    {
        get
        {
            return _ENP;
        }
    }
    public static string RawString
    {
        get
        {
            return _FEN;
        }
    }
    public static bool WhiteCanCastleQueenSide
    {
        get
        {
            return _wccqs;
        }
    }
    public static bool WhiteCanCastleKingsSide
    {
        get
        {
            return _wccks;
        }
    }
    public static bool BlackCanCastleQueenSide
    {
        get
        {
            return _bccqs;
        }
    }
    public static bool BlackCanCastleKingsSide
    {
        get
        {
            return _bccks;
        }
    }
    public static bool isWhiteMove
    {

        get
        {
            return _isWhiteMove;
        }

    }
    public static bool isValid
    {

        get
        {
            return _isValid;
        }

    }
    public static int[,] Layout
    {

        get
        {
            return _board;
        }

    }

    public static int HalfMoveClock
    {
        get
        {
            return _HMC;
        }
    }
    public static int FullMoveNumber
    {
        get
        {
            return _FMN;
        }
    }

    public static bool validateFEN(string str) {

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

        _FEN = str;

        return true;

    }

    private static bool CheckHalfMoveClock(string halfMoveClock)
    {

        if (!Int32.TryParse(halfMoveClock, out _HMC)) return false;
        return true;
    }

    private static bool CheckFullMoveNumber(string fullMoveNumber)
    {
        if (!Int32.TryParse(fullMoveNumber, out _FMN)) return false;
        return true;
    }
    private static bool CheckEnPesant(string enPesant)
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

    private static bool CheckCastle(string castle)
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

    private static bool CheckSquares(string rankString,int rankNumber)
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
                    _board[rank,7 - f] = 0; }

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

                _board[rank, 7 - squaresCount] = buff;
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
