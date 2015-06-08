using System;
using System.Collections.Generic;
using System.Linq;

namespace poker
{
	public class Hand
	{
		private readonly List<char> suits = new List<char>(){'H', 'C', 'D','S'};
		private readonly List<char> values = new List<char>(){'2', '3','4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};

		public Hand (List<string> cards)
		{
			Cards = cards;
		}

		public List<string> Cards {
			get;
			set;
		}

		public bool isValid()
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

		private bool isValidCard (string card)
		{
			if (card.Length != 2) {
				return false;
			}
			return values.Contains (card [0]) && suits.Contains (card [1]);
		}

		public bool noDuplicateCards (Hand otherHand)
		{
			HashSet<string> bothHands = new HashSet<string> ();

			bothHands.UnionWith (Cards);
			bothHands.UnionWith (otherHand.Cards);

			return bothHands.Count == 10;
		}

		public string highCard(){
			return values[this.Cards.Max (c => values.IndexOf(c[0]))].ToString();
		}

	}
}

