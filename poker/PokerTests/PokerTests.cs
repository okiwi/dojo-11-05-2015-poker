using NUnit.Framework;
using NUnit.Core;
using System;
using System.Collections.Generic;
using poker;

namespace PokerTests
{
	[TestFixture()]
	public class PokerTests
	{
		private Poker game;

		[SetUp()]
		public void setup() {
			game = new Poker ();
		}

		[Test()]
		public void canEvaluateATurnWithAStraight ()
		{
			var firstHand = new List<string> () { "8S", "9H", "TS", "JC", "QD" };
			var secondHand = new List<string> () { "8H", "3H", "TD", "JS", "QS" };

			var result = game.evaluate (firstHand, secondHand);

			Assert.AreEqual ("firstHand", result.Winner);
			Assert.AreEqual ("Straight", result.Rank);
		}

		[Test()]
		public void canEvaluateATurnWithSecondHandAsStraight ()
		{
			var firstHand = new List<string> () { "8S", "3H", "TS", "JC", "QD" };
			var secondHand = new List<string> () { "8H", "9H", "TD", "JS", "QS" };

			var result = game.evaluate (firstHand, secondHand);

			Assert.AreEqual ("secondHand", result.Winner);
			Assert.AreEqual ("Straight", result.Rank);
		}

		[Test()]
		[ExpectedException(typeof(ArgumentException))]
		public void canInvalidateATurnWithSameCard ()
		{
			var firstHand = new List<string>() { "8S", "3H", "KS", "9C", "KD"};
			var secondHand = new List<string>() { "8S", "3H", "KS", "9C", "KD"};

			game.evaluate (firstHand, secondHand);
		}

		[Test()]
		[ExpectedException(typeof(ArgumentException))]
		public void canInvalidateATurnWithInvalidCardsOnFirstHand ()
		{
			var firstHand = new List<string> () { "8S", "sd", "TS", "JC", "QD" };
			var secondHand = new List<string> () { "8H", "3H", "TD", "JS", "QS" };

			game.evaluate (firstHand, secondHand);
		}

		[Test()]
		[ExpectedException(typeof(ArgumentException))]
		public void canInvalidateATurnWithInvalidCardsOnSecondHand ()
		{
			var firstHand = new List<string> () { "8S", "3H", "TS", "JC", "QD" };
			var secondHand = new List<string> () { "8H", "sd", "TD", "JS", "QS" };

			game.evaluate (firstHand, secondHand);
		}
	}
}