using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace poker
{

	public class Poker
	{
		public bool isValidTurn (Hand firstHand, Hand secondHand){
			HashSet<string> bothHands = new HashSet<string> ();

			if (!firstHand.isValidHand ())
				return false;
			if (!secondHand.isValidHand ())
				return false;

			bothHands.UnionWith (firstHand.Cards);
			bothHands.UnionWith (secondHand.Cards);

			if (bothHands.Count != 10) {
				return false;
			}
			return true;
		}

		public bool isAStraight (Hand firstHand){
			if (!firstHand.isValidHand ())
				return false;

			var values = new List<char> ();
			foreach (var card in firstHand.Cards) {
				values.Add (card [0]);
			}
			values.Sort ();

			bool aceHigh = false;
			bool aceLow = false;
			if (firstHand.hasAce) 
			{
				aceHigh = firstHand.aceHigh;
				aceLow = firstHand.aceLow;
			}

			var firstCardValue = values [0];
			var firstCardIdx = Constants.Suite.IndexOf (firstCardValue);
			if (aceHigh) { // special case for royal straight
				firstCardIdx = 9;
			} 
			if (aceLow) { // special case for low straight
				firstCardIdx = 0;
			}

			if (firstCardIdx + 5 > Constants.Suite.Count)
				return false;

			var suiteValues = Constants.Suite.GetRange (firstCardIdx, 5);
			suiteValues.Sort ();

			var sameCards = Enumerable.SequenceEqual(values, suiteValues);

			var straight = Constants.Values.Intersect (values).ToList();
			return straight.Count == values.Count && sameCards;
		}
	}
}

 