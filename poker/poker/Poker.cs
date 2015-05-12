using System;
using System.Collections;
using System.Collections.Generic;

namespace poker
{

	public class Poker
	{
		public bool isValidTurn (Hand firstHand, Hand secondHand){
			HashSet<string> bothHands = new HashSet<string> ();

			bothHands.UnionWith (firstHand.Cards);
			bothHands.UnionWith (secondHand.Cards);

			if (bothHands.Count != 10) {
				return false;
			}
			return true;
		}

		public bool isAStraight (Hand firstHand){
			var indexes = new List<int> ();

			foreach (var card in firstHand.Cards) {
				indexes.Add (Constants.Suite.IndexOf (card [0]));
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

