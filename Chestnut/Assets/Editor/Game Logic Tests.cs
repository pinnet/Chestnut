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
            FENString fENString = new FENString("RNBKQBNR PPPPPPPP 6 8 8 8 pppppppp rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(fENString.isValid);
        }
        [Category("Failing Tests")]
        public void OneEmptyTooMany()
        {
            FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 9 pppppppp rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(fENString.isValid);
        }

        [Test]
        [Category("Failing Tests")]
        public void OnePieceShort()
        {
            FENString fENString = new FENString("RNBKQBNR PPPPPPP 8 8 8 8 pppppppp rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(fENString.isValid);
        }
        [Test]
        [Category("Failing Tests")]
        public void OneTooManyPieces()
        {
            FENString fENString = new FENString("RNBKQBNR PPPPPPP 8 8 8 8 ppppppppp rnbqkbnr w KQqk - 0 0");
            Assert.IsFalse(fENString.isValid);
        }
        [Test]
        [Category("Failing Tests")]
        public void TooManySpaces()
        {
            FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr  w KQqk - 0 0");
            Assert.IsFalse(fENString.isValid);
        }
    [Test]
    [Category("Passing Tests")]
    public void isWhiteMove()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w KQ - 7 0");
        Assert.IsTrue(fENString.isValid);
        Assert.IsTrue(fENString.isWhiteMove);
    }

    [Test]
    [Category("Passing Tests")]
    public void HalfMoveClock()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w KQ - 7 0");

        Assert.IsTrue(fENString.isValid);
        Assert.IsTrue(condition: fENString.HalfMoveClock == 7);

    }
    [Test]
    [Category("Passing Tests")]
    public void FullMoveNumber()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w KQ - 7 300");

        Assert.IsTrue(fENString.isValid);
        Assert.IsTrue(condition: fENString.FullMoveNumber == 300);

    }
    [Test]
    [Category("Passing Tests")]
    public void WhiteKingAndQueenSideCastle()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w KQ - 0 0");

        Assert.IsTrue(fENString.isValid);
        Assert.IsTrue(fENString.WhiteCanCastleKingsSide);
        Assert.IsTrue(fENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(fENString.BlackCanCastleKingsSide);
        Assert.IsFalse(fENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void WhiteKingSideCastle()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w K - 0 0");

        Assert.IsTrue(fENString.isValid);
        Assert.IsTrue(fENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(fENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(fENString.BlackCanCastleKingsSide);
        Assert.IsFalse(fENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void WhiteQueenSideCastle()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w Q - 0 0");

        Assert.IsTrue(fENString.isValid);
        Assert.IsFalse(fENString.WhiteCanCastleKingsSide);
        Assert.IsTrue(fENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(fENString.BlackCanCastleKingsSide);
        Assert.IsFalse(fENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void BlackKingAdnQueenSideCastle()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w kq - 0 0");

        Assert.IsTrue(fENString.isValid);
        Assert.IsFalse(fENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(fENString.WhiteCanCastleQueenSide);
        Assert.IsTrue(fENString.BlackCanCastleKingsSide);
        Assert.IsTrue(fENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void BlackKingSideCastle()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w k - 0 0");

        Assert.IsTrue(fENString.isValid);
        Assert.IsFalse(fENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(fENString.WhiteCanCastleQueenSide);
        Assert.IsTrue(fENString.BlackCanCastleKingsSide);
        Assert.IsFalse(fENString.BlackCanCastleQueenSide);
    }
    [Test]
    [Category("Passing Tests")]
    public void BlackQueenSideCastle()
    {
        FENString fENString = new FENString("RNBKQBNR PPPPPPPP 8 8 8 8 pppppppp rnbqkbnr w q - 0 0");

        Assert.IsTrue(fENString.isValid);
        Assert.IsFalse(fENString.WhiteCanCastleKingsSide);
        Assert.IsFalse(fENString.WhiteCanCastleQueenSide);
        Assert.IsFalse(fENString.BlackCanCastleKingsSide);
        Assert.IsTrue(fENString.BlackCanCastleQueenSide);
    }
}


