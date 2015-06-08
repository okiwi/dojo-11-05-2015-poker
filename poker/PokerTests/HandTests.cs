using System;
using NUnit.Framework;
using NUnit.Core;
using poker;

namespace PokerTests
{
	[TestFixture()]
	public class HandTests
	{
		[Test()]
		public void AHandCanValidateItself ()
		{
			var hand = new Hand (new System.Collections.Generic.List<string> () { "2H", "3H", "4H", "5H", "8D" });

			Assert.IsTrue (hand.isValid ());
		}

		[Test()]
		public void CanReturnHighCard ()
		{
			var hand = new Hand (new System.Collections.Generic.List<string> () { "2H", "3H", "4H", "5H", "8D" });
			var highCard = hand.highCard ();

			Assert.AreEqual ("8", highCard); 
		}
	}
}

