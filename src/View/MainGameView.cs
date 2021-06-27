using System;
namespace DinoGame.Views{
    public class MainGameView{

        protected void WriteMainMenu(){
            Console.Clear();
            Console.WriteLine(("").PadRight(80, '='));
            Console.WriteLine("--------------------         BATALHA DE DINOSSAUROS         --------------------");
            Console.WriteLine(("").PadRight(80, '='));
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