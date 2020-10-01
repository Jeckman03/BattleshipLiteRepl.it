using System;
using System.Collections.Generic;


public class GridSpot {

	public string SpotLetter { get; set; }

	public int SpotNumber { get; set; }

	public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;
	
}