using System;
using System.Collections.Generic;

namespace poker
{
	public static class Constants
	{
		public static readonly List<char> Suits = new List<char>(){'H', 'C', 'D','S'};
		public static readonly List<char> Values = new List<char>(){'A', '2', '3','4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K'};
		public static readonly List<char> Suite = new List<char>(){'A', '2', '3','4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'};
	}
}

