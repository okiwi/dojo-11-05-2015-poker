using System;
using System.Collections;
using System.Collections.Generic;

namespace poker
{

	public class Poker
	{

		
		private readonly List<char> suite = new List<char>(){'A', '2', '3','4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};

		public Poker ()
		{
		}

		public PokerResult evaluate (List<string> firstHand, List<string> secondHand)
		{
			var first = new Hand (firstHand);
			var second = new Hand (secondHand);

			if (!isValidTurn(first, second)) {
				throw new ArgumentException ();
			}
			if (isAStraight (first)) {
				return new PokerResult () { Winner = "firstHand", Rank = "Straight" };
			}
			if (isAStraight (second)) {
				return new PokerResult () { Winner = "secondHand", Rank = "Straight" };
			}
			return new PokerResult ();
		}

		private bool isValidTurn (Hand firstHand, Hand secondHand){
			if (!firstHand.isValid() || !secondHand.isValid()) {
				return false;
			}
			return firstHand.noDuplicateCards (secondHand);

		}

		private bool isAStraight (Hand hand){
			var indexes = new List<int> ();

			foreach (var card in hand.Cards) {
				indexes.Add (suite.IndexOf (card [0]));
			}

			indexes.Sort ();

			var lastIndex = -1;
			foreach (var item in indexes) {
				if (lastIndex == -1) {
					lastIndex = item;
				} else if(item != lastIndex + 1){
					return false;
				}

				lastIndex = item;

			}


			return true;
		}
	}
}

