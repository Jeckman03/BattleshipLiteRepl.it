using System;
using System.Collections.Generic;

public class PlayerModel {

	public string Name { get; set; }
	
	public List<GridSpotModel> ShipLocations { get; set; }

	public List<GridSpotModel> ShotGrid { get; set; }
}