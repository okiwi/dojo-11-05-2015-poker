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
			return hand.Count == 5;
		}
	}
}

