using System;
using System.Collections.Generic;

namespace BattleShipLiteLibrary 
{

	public class GridSpot 
	{

		public string SpotLetter { get; set; }

		public int SpotNumber { get; set; }

		public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;

	}
}
