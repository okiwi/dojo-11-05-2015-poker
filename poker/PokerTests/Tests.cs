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
			var hand =  new List<string>() { "2H", "3D", "5S", "9C", "KD"};

			var game = new Poker ();
			var goodHand = game.isValidHand (hand);

			Assert.IsTrue (goodHand);
		}

	}
}

