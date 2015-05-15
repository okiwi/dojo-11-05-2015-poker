using NUnit.Framework;
using NUnit.Core;
using System;
using System.Collections.Generic;
using poker;

namespace PokerTests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void isValidHand ()
		{
			var hand = new Hand( new List<string>() { "2H", "3D", "5S", "9C", "KD"});

			var goodHand = hand.isValidHand ();

			Assert.IsTrue (goodHand);
		}

		[Test()]
		public void handCantHaveMoreThan5Cards ()
		{
			var hand = new Hand( new List<string>() { "2H", "3D", "5S", "9C", "KD", "3C" });

			var goodHand = hand.isValidHand ();

			Assert.AreEqual (5, hand.Cards.Count);
			Assert.IsTrue (goodHand);
		}

		[Test()]
		public void handIsAceHigh ()
		{
			var hand = new Hand( new List<string>() { "2H", "3D", "5S", "9C", "AD" });

			var goodHand = hand.isValidHand ();

			Assert.AreEqual (5, hand.Cards.Count);
			Assert.IsTrue (goodHand);
		}

		[Test()]
		public void handIsAceLow ()
		{
			var hand = new Hand( new List<string>() { "AH", "3D", "5S", "9C", "KD", "3C" });

			var goodHand = hand.isValidHand ();

			Assert.AreEqual (5, hand.Cards.Count);
			Assert.IsTrue (goodHand);
		}

		[Test()]
		public void isNotValidHand ()
		{
			var hand = new Hand( new List<string>() { "fo", "ba", "ba", "9C", "KD"});

			var goodHand = hand.isValidHand ();

			Assert.IsFalse (goodHand);
		}

		[Test()]
		public void isNotValidTurn ()
		{
			var firstHand = new Hand( new List<string>() { "8S", "3H", "KS", "9C", "KD"});
			var secondHand = new Hand( new List<string>() { "8S", "3H", "KS", "9C", "KD"});

			var game = new Poker ();
			var goodTurn = game.isValidTurn (firstHand, secondHand);

			Assert.IsFalse (goodTurn);
		}

		[Test()]
		public void isAStraight ()
		{
			var firstHand = new Hand( new List<string>() { "8S", "9H", "TS", "JC", "QD"});

			var game = new Poker ();
			var goodHand = game.isAStraight (firstHand);

			Assert.IsTrue (goodHand);

			// sanity check

			var secondHand = new Hand( new List<string>() { "2S", "3H", "4S", "5C", "6D"});

			goodHand = game.isAStraight (secondHand);

			Assert.IsTrue (goodHand);

			// still not sure

			var thirdHand = new Hand( new List<string>() { "AS", "2H", "3S", "4C", "5D"});

			goodHand = game.isAStraight (thirdHand);

			Assert.IsTrue (goodHand);
		}

		[Test]
		public void isNotAStraight(){
			var firstHand = new Hand( new List<string>() { "8S", "8H", "TS", "TC", "QD"});

			var game = new Poker ();
			var twoPairsHand = game.isAStraight (firstHand);

			Assert.IsFalse (twoPairsHand);

			// maybe not 

			var secondHand = new Hand( new List<string>() { "7S", "9H", "TS", "JC", "QD"});

			var fourInARowHand = game.isAStraight (secondHand);

			Assert.IsFalse (fourInARowHand);

		}

		[Test()]
		public void isRoyalStraight ()
		{
			var firstHand = new Hand (new List<string> () { "TS", "JC", "QD", "KH", "AD" });

			var game = new Poker ();
			var goodHand = game.isAStraight (firstHand);

			Assert.IsTrue (goodHand);
		}

		[Test()]
		public void isWeakStraight ()
		{
			var firstHand = new Hand (new List<string> () { "AS", "2C", "3D", "4H", "5D" });

			var game = new Poker ();
			var goodHand = game.isAStraight (firstHand);

			Assert.IsTrue (goodHand);
		}

		[Test()]
		public void detectUnorderedStraight ()
		{
			var firstHand = new Hand (new List<string> () { "TS", "8S", "QD", "9H", "JC" });

			var game = new Poker ();
			var goodHand = game.isAStraight (firstHand);

			Assert.IsTrue (goodHand);
		}
	}
}

