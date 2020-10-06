using System;
using System.Collections.Generic;
using Models.BattleShipLiteLibrary;

namespace BattleshipLite
{
	
	class MainClass {
  	public static void Main (string[] args) {

			//Main
			WelcomeMessage();

  	  Console.ReadLine();
  	}

		//methods
		private static void WelcomeMessage() 
		{
			Console.WriteLine("Welcome to Battleship Lite!");
			Console.WriteLine("Created by: Jeff Eckman");
			Console.WriteLine();
		}

		private static PlayerInfoModel CreatePlayer() 
		{
			PlayerInfoModel output = new PlayerInfoModel();

			//ask the user for their namespace
			output.Name = AskForUsersName();

			//load up the shot grid
			output.ShotGrid
			
			//ask the user for their 5 ship placements
			//clear
		}

		private static string AskForUsersName() 
		{
			Console.Write("What is your name: ");
			string output = Console.ReadLine();

			return output;
		}
	}
}
