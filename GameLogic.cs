using System;
using BattleShipLiteLibrary;
using System.Collections.Generic;

namespace BattleShipLiteLibrary
{

	public static class GameLogic 
	{
		public static void InitializeGrid(PlayerInfoModel model)
		{
			List<string> letters = new List<string> 
			{
				"A",
				"B",
				"C",
				"D",
				"E"
			};

			List<int> numbers = new List<int> 
			{
				1,
				2,
				3,
				4,
				5
			};

			foreach (string letter in letters) 
			{
				foreach (int number in numbers)
				{
					AddGridSpot(model, letter, number);
				}
			}
		}

		private static void AddGridSpot(PlayerInfoModel model, string letter, int number) {
			GridSpotModel spot = new GridSpotModel();
			spot.SpotLetter = letter;
			spot.SpotNumber = number;
			spot.Status = GridSpotStatus.Empty;

			model.ShotGrid.Add(spot);
		}

		public static bool StoreShot(PlayerInfoModel model, string location) {
			throw new NotImplementedException();
		}
	}
}