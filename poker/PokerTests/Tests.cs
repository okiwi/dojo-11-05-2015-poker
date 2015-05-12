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
		}

	}
}

