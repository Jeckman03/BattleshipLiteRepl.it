using System;
using BattleShipLiteLibrary;
using System.Collections.Generic;

namespace BattleShipLiteLibrary
{

	public static class GameLogic 
	{
		public static void MarkShotResult(PlayerInfoModel activePlayer, string row, int column, bool isHit)
		{

		}

		public static bool IdentifyShotResult(PlayerInfoModel opponent, string row, int column)
		{

		}

		public static bool ValidateShot(PlayerInfoModel activePlayer, string row, int column)
		{

		}

		public static (string, int) SplitShotIntoRowAndColumn(string shot)
		{

		}

		public static int GetShotCount(PlayerInfoModel winner)
		{

		}

		public static bool PlayerStillActive(PlayerInfoModel opponent)
		{

		}

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