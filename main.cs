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
				DisplayShotGrid(activePlayer)

				RecordPlayerShot(activePlayer, opponent);

				bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

				if (doesGameContinue == true)
				{
					// Swap using a temp variable
					// PlayerInfoModel tempHolder = opponent;
					// opponent = activePlayer;
					// activePlayer = tempHolder;
					// OR
					// Use Tuple to swap positions
					(activePlayer, opponent) = (opponent, activePlayer);
				}
				else{
					winner = activePlayer;
				}

			} while (winner == null);

			IdentifyWinner(winner);

  	  Console.ReadLine();
  	}

		//methods
		private static void IdentifyWinner(PlayerInfoModel winner)
		{
			Console.WriteLine($"Congratulations to { winner } for winning!");
			Console.WriteLine($"{ winner.UsersName } took { GameLogic.GetShotCount(winner) } shots.");
		}

		private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
		{
			bool isValidShot = false;
			string row = "";
			int column = 0;

			do
			{
				string shot = AskForShot();
				(row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
				isValidShot = GameLogic.ValidateShot(activePlayer, row, column);

				if (isValidShot == false) 
				{
					Console.WriteLine("Invalid Shot Location. Please try again.");
				}
			} while (isValidShot == false);

			bool isHit = GameLogic.IdentifyShotResult(opponent, row, column);

			GameLogic.MarkShotResult(activePlayer, row, column, isHit);
		}

		private static void AskForShot()
		{
			Console.Write("Please enter your shot selection: ");
			string output = Console.ReadLine();

			return output;
		}

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
					Console.Write(" X ");
				}
				else if (gridSpot.Status == GridSpotStatus.Miss)
				{
					Console.Write(" O ");
				}
				else
				{
					Console.Write(" ? ");
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
