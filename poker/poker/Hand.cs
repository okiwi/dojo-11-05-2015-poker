using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace poker
{
	public class Hand
	{

		public Hand(List<string> cards)
		{
			Cards = cards;
		}

		public List<string> Cards {
			get;
			set;
		}

		public bool isValidHand()
		{
			if (this.Cards.Count != 5) {
				return false;
			}

			foreach(var card in this.Cards){

				if (!isValidCard (card)) {
					return false;
				}
			}

			return true;
		}

		public bool isValidCard (string card)
		{
			if (card.Length != 2) {
				return false;
			}
			return Constants.Values.Contains (card [0]) && Constants.Suits.Contains (card [1]);
		}
	}
}

