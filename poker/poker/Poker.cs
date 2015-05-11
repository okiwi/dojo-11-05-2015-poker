using System;
using System.Collections;
using System.Collections.Generic;

namespace poker
{

	public class Poker
	{
		private readonly List<char> suits = new List<char>(){'H', 'C', 'D','S'};
		private readonly List<char> values = new List<char>(){'A', '2', '3','4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K'};
		private readonly List<char> suite = new List<char>(){'A', '2', '3','4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};


		public Poker ()
		{
		}

		bool isValidCard (string card)
		{
			if (card.Length != 2) {
				return false;
			}
			return values.Contains (card [0]) && suits.Contains (card [1]);
		}

		public bool isValidHand(List<string> hand)
		{
			if (hand.Count != 5) {
				return false;
			}

			foreach(var card in hand){

				if (!isValidCard (card)) {
					return false;
				}
			}

			return true;
		}

		public bool isValidTurn (List<string> firstHand, List<string> secondHand){
			HashSet<string> bothHands = new HashSet<string> ();

			bothHands.UnionWith (firstHand);
			bothHands.UnionWith (secondHand);

			if (bothHands.Count != 10) {
				return false;
			}
			return true;
		}

		public bool isAStraight (List<string> firstHand){
			var indexes = new List<int> ();

			foreach (var card in firstHand) {
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

