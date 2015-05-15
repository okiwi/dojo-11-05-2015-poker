using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace poker
{
	public class Hand
	{
		public bool aceHigh {
			get{
				if (this.hasAce) {
					var aceAndKing = (from c in this.Cards
										where c [0] == 'K'
										select c).FirstOrDefault();

					return aceAndKing != null;
				}
				return false;
			}
		}

		public bool aceLow {
			get{
				if (this.hasAce) {
					var aceAndTwo = (from c in this.Cards
										where c [0] == '2'
										select c).FirstOrDefault();
					return aceAndTwo != null;
				}
				return false;
			}
		}

		public bool hasAce {
			get{
				var ace = (from c 
							in this.Cards 
							where c [0] == 'A' 
							select c).FirstOrDefault();
				return ace != null;
			}
		}

		public Hand(List<string> cards)
		{
			if (cards.Count > 5) {
				cards.RemoveRange (5, cards.Count - 5);
			}
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

