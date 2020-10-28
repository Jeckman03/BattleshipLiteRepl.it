using System;
using System.Collections.Generic;
using BattleShipLiteLibrary;

namespace BattleshipLite
{
	
	class MainClass {
  	public static void Main (string[] args) {

			//Main
			WelcomeMessage();

			PlayerInfoModel activePlayer = CreatePlayer("Player 1");
			PlayerInfoModel opponent = CreatePlayer("Player 2");
			PlayerInfoModel winner = null;

			do {
				// Display grid from activePlayer on where they fired
				DisplayShotGrid(activePlayer)

				// Ask activePlayer for a shot
				// Determine if it is a valid shot
				// Determine shot results
				// Determine if the game is over
				// If over, set activePlayer as winner
				// else, swap positions (activePlayer to opponent)

			} while (winner == null);


  	  Console.ReadLine();
  	}

		//methods
		private static void DisplayShotGrid(PlayerInfoModel activePlayer) 
		{
			string currentRow = activePlayer.ShotGrid[0].SpotLetter;

			foreach (var gridSpot in activePlayer.ShotGrid) 
			{
				if (gridSpot.SpotLetter != currentRow)
				{
					Console.WriteLine();
					currentRow = gridSpot.SpotLetter;
				}

				if (gridSpot.Status == GridSpotStatus.Empty)
				{
					Console.Write($" { gridSpot.SpotLetter }{ gridSpot.SpotNumber } ");
				}
				else if (gridSpot.Status == GridSpotStatus.Hit)
				{
					Console.WriteLine(" X ");
				}
				else if (gridSpot.Status == GridSpotStatus.Miss)
				{
					Console.WriteLine(" O ");
				}
				else
				{
					Console.WriteLine(" ? ");
				}
			}
		}

		private static void WelcomeMessage() 
		{
			Console.WriteLine("Welcome to Battleship Lite!");
			Console.WriteLine("Created by: Jeff Eckman");
			Console.WriteLine();
		}

		private static PlayerInfoModel CreatePlayer(string playerTitle) 
		{
			PlayerInfoModel output = new PlayerInfoModel();

			Console.WriteLine($"Information for { playerTitle }:");

			//ask the user for their namespace
			output.Name = AskForUsersName();

			//load up the shot grid
			GameLogic.InitializeGrid(output);
			
			//ask the user for their 5 ship placements
			GetShipPlacements(output);
			
			//clear
			Console.Clear();

			return output;
		}

		private static string AskForUsersName() 
		{
			Console.Write("What is your name: ");
			string output = Console.ReadLine();

			return output;
		}

		private static void GetShipPlacements(PlayerInfoModel model) {
			do {
				Console.Write($"Where would you like to place ship number { model.ShipLocations.Count + 1 }: ");
				string location = Console.ReadLine();

				bool isValidPlacement = GameLogic.StoreShot(model, location);

			} while (model.ShipLocations.Count < 5);
		}
	}
}
