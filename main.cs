using System;
using System.Collections.Generic;
using BattleShipLiteLibrary;

namespace BattleshipLite
{
	
	class MainClass {
  	public static void Main (string[] args) {

			//Main
			WelcomeMessage();

			PlayerInfoModel player1 = CreatePlayer("Player 1");
			PlayerInfoModel player2 = CreatePlayer("Player 2");

  	  Console.ReadLine();
  	}

		//methods
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
