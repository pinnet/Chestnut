using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;


    [TestFixture]
    [Category("FENString Validation Tests")]
    internal class FENStringValidationTest
    {
        [Test]
        [Category("Failing Tests")]
        public void TwoFilesShort()
        {
            FENString.ParseString("RNBKQBNR/PPPPPPPP/6/8/8/8/pppppppp/rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(FENString.isValid);
        }
        [Category("Failing Tests")]
        public void OneEmptyTooMany()
        {
            FENString.ParseString("RNBKQBNR/PPPPPPP/8/8/8/9/pppppppp/rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(FENString.isValid);
        }

        [Test]
        [Category("Failing Tests")]
        public void OnePieceShort()
        {
            FENString.ParseString("RNBKQBNR/PPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(FENString.isValid);
        }
        [Test]
        [Category("Failing Tests")]
        public void OneTooManyPieces()
        {
            FENString.ParseString("RNBKQBNR/PPPPPPP/8/8/8/8/ppppppppp/rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(FENString.isValid);
        }
        [Test]
        [Category("Failing Tests")]
        public void TooManySpaces()
        {
            FENString .ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr  w KQqk - 0 0");
            Assert.IsFalse(FENString.isValid);
        }
    [Test]
    [Category("Passing Tests")]
    public void isWhiteMove()
    {
        FENString .ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w KQ - 7 0");
        Assert.IsTrue(FENString.isValid);
        Assert.IsTrue(FENString.isWhiteMove);
    }

    [Test]
    [Category("Passing Tests")]
    public void HalfMoveClock()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w KQ - 7 0");

        Assert.IsTrue(FENString.isValid);
        Assert.IsTrue(condition: FENString.HalfMoveClock == 7);

    }
    [Test]
    [Category("Passing Tests")]
    public void FullMoveNumber()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w KQ - 7 300");

        Assert.IsTrue(FENString.isValid);
        Assert.IsTrue(condition: FENString.FullMoveNumber == 300);

    }
    [Test]
    [Category("Passing Tests")]
    public void WhiteKingAndQueenSideCastle()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w KQ - 0 0");

        Assert.IsTrue(FENString.isValid);
        Assert.IsTrue(FENString.WhiteCanCastleKingsSide);
        Assert.IsTrue(FENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(FENString.BlackCanCastleKingsSide);
        Assert.IsFalse(FENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void WhiteKingSideCastle()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w K - 0 0");

        Assert.IsTrue(FENString.isValid);
        Assert.IsTrue(FENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(FENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(FENString.BlackCanCastleKingsSide);
        Assert.IsFalse(FENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void WhiteQueenSideCastle()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w Q - 0 0");

        Assert.IsTrue(FENString.isValid);
        Assert.IsFalse(FENString.WhiteCanCastleKingsSide);
        Assert.IsTrue(FENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(FENString.BlackCanCastleKingsSide);
        Assert.IsFalse(FENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void BlackKingAdnQueenSideCastle()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w kq - 0 0");

        Assert.IsTrue(FENString.isValid);
        Assert.IsFalse(FENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(FENString.WhiteCanCastleQueenSide);
        Assert.IsTrue(FENString.BlackCanCastleKingsSide);
        Assert.IsTrue(FENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void BlackKingSideCastle()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w k - 0 0");

        Assert.IsTrue(FENString.isValid);
        Assert.IsFalse(FENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(FENString.WhiteCanCastleQueenSide);
        Assert.IsTrue(FENString.BlackCanCastleKingsSide);
        Assert.IsFalse(FENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void BlackQueenSideCastle()
    {
        FENString.ParseString("RNBKQBNR/PPPPPPPP/8/8/8/8/pppppppp/rnbqkbnr w q - 0 0");

        Assert.IsTrue(FENString.isValid);
        Assert.IsFalse(FENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(FENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(FENString.BlackCanCastleKingsSide);
        Assert.IsTrue(FENString.BlackCanCastleQueenSide);
    }


    [Test]
    [Category("Passing Tests")]
    public void Move1WikiPedia()
    {
        FENString.ParseString("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1");

        Assert.IsTrue(FENString.isValid);
       
    }
    [Test]
    [Category("Passing Tests")]
    public void Move3WikiPedia()
    {
        FENString.ParseString("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2");

        Assert.IsTrue(FENString.isValid);

    }



}


