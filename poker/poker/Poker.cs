using System;
using System.Collections.Generic;

namespace poker
{

	public class Poker
	{
		private List<char> suits = new List<char>(){'H', 'C', 'D','S'};
		private List<char> values = new List<char>(){'A', '2', '3','4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K'};
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
	}
}

