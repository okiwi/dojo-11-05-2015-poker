using System;
using System.Collections.Generic;

namespace poker
{
	public class Poker
	{
		public Poker ()
		{
		}

		public bool isValidHand(List<string> hand)
		{
			if (hand.Count != 5) {
				return false;
			}

			foreach(var card in hand){
				if (card.Length != 2) {
					return false;
				}
			}

			return true;
		}
	}
}

