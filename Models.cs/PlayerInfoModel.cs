using System;
using System.Collections.Generic;
using BattleShipLiteLibrary;

namespace BattleShipLiteLibrary
{

	public class PlayerInfoModel 
	{

		public string Name { get; set; }

		public List<GridSpotModel> ShipLocations { get; set; } = new List<GridSpotModel>();

		public List<GridSpotModel> ShotGrid { get; set; } = new List<GridSpotModel>();
	}		
}

