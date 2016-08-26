using System;

namespace Assignment_Practice
{
	class Program {


		public static Coordinate Hero 
		{
			get;
			set;
		} 

		static string[,] levelPlan =  new string[11, 21] 
		{ 
			{"+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+"}, 
			{"+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+"},
			{"+","+","x","+","+","+","+","+","+","+","+","+","+","+","+","+","+","=","+","x","+"}, 
			{"+","+","x","+","+","+","+","+","+","+","+","+","o","+","o","+","+","+","+","x","+"},
			{"+","+","x","+","+","+","+","+","+","+","+","+","o","+","o","+","+","+","+","x","+"},
			{"+","+","x","+","+","+","+","+","+","+","+","+","o","+","o","+","+","+","+","x","+"},
			{"+","+","x","+","+","+","+","+","+","+","+","+","o","+","o","+","+","+","+","x","+"},
			{"+","+","x","+","+","+","+","+","+","+","+","+","o","+","o","+","+","+","+","x","+"},
			{"+","+","x","+","+","+","+","+","+","+","+","+","o","+","o","+","+","+","+","x","+"},
			{"+","+","x","+","+","+","+","+","+","+","+","+","o","+","o","+","+","+","+","x","+"},
			{"+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+","+"}
		};

		static void Main(string[] args) 
		{

			InitGame ();
			ConsoleKeyInfo keyInfo;
			while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape) {
				switch (keyInfo.Key) {
				case ConsoleKey.UpArrow:
					MoveHero(0, -1);
					break;

				case ConsoleKey.RightArrow:
					MoveHero(1, 0);
					break;

				case ConsoleKey.DownArrow:
					MoveHero(0, 1);
					break;

				case ConsoleKey.LeftArrow:
					MoveHero(-1, 0);
					break;
				}
			}
		}

		/*static void MoveHero(int x, int y)
		{
			Coordinate newHero = new Coordinate()
			{
				X = Hero.X + x,
				Y = Hero.Y + y
			};

			if (CanMove(newHero)) 
			{
				RemoveHero();

				Console.SetCursorPosition(newHero.X, newHero.Y);
				Console.Write(" ");

				Hero = newHero;
			}
		}*/


		static void RemoveHero() 
		{
			Console.SetCursorPosition(Hero.X, Hero.Y);
			Console.Write("");
		}

		public static bool CheckMove(int newY, int newX) 
		{
			if (levelPlan[newX, newY] == "x")
				return false;
			if (newY < 0 || newY > Console.WindowHeight || newX < 0 || newX > Console.WindowHeight)
				return false;
			return true;
		}

		static void MoveHero(int x, int y)
		{
			Coordinate newHero = new Coordinate()
			{
				X = Hero.X + x,
				Y = Hero.Y + y
			};

			if (CheckMove(newHero.X, newHero.Y) && CanMove(newHero)) 
			{
				RemoveHero();


				Console.SetCursorPosition(newHero.X, newHero.Y);
				Console.Write(" ");

				Hero = newHero;
			}
		}

		static bool CanMove(Coordinate c) 
		{
			if (c.X < 0 || c.X >= Console.WindowWidth)
				return false;

			if (c.Y < 0 || c.Y >= Console.WindowHeight)
				return false;

			return true;
		}


		static void SetBackgroundColor() 
		{
			Console.Clear(); 
		}


		static void InitGame() {
			SetBackgroundColor();
			int rowLength = levelPlan.GetLength(0);
			int colLength = levelPlan.GetLength(1);

			for (int i = 0; i < rowLength; i++)
			{
				for (int j = 0; j < colLength; j++)
				{
					Console.Write(string.Format("{0} ", levelPlan[i, j]));
				}
			
				Console.Write("\n");
			}

			Hero = new Coordinate() {
				X = 5,
				Y = 5
			};

			MoveHero(0, 0);

		}

	}


	/// <summary>
	/// Represents a map coordinate
	/// </summary>
	class Coordinate {
		public int X {
			get;
			set;
		} //Left
		public int Y {
			get;
			set;
		} //Top
	}


}

