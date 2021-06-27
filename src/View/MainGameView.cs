using System;
using DinoGame.Util;
namespace DinoGame.Views{
    public class MainGameView{

        protected void WriteMainMenu(){
            Console.Clear();
            ScreenUtility.WriteColoredString(("").PadRight(80, '='), ConsoleColor.Black, ConsoleColor.DarkGreen);
            ScreenUtility.WriteColoredString("--------------------         BATALHA DE DINOSSAUROS         --------------------", ConsoleColor.Black, ConsoleColor.DarkGreen);
            ScreenUtility.WriteColoredString(("").PadRight(80, '='), ConsoleColor.Black, ConsoleColor.DarkGreen);
            Console.WriteLine();
        }

        protected void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, currentLineCursor);
        }

    }
}