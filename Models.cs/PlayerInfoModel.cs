using System;
using System.Collections.Generic;

namespace BattleShipLiteLibrary
{

	public class PlayerInfoModel 
	{

		public string Name { get; set; }

		public List<GridSpotModel> ShipLocations { get; set; }

		public List<GridSpotModel> ShotGrid { get; set; }
	}		
}

