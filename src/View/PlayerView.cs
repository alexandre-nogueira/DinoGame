using System;
using DinoGame.Util;
using DinoGame.Models;

namespace DinoGame.Views{
    public class PlayerView : MainGameView{
    public string playerNameLabel;

    //Create new player screen
        public string GetPlayerName(){
            WriteMainMenu();
            Console.Write("Nome do Jogador " + playerNameLabel + " : ");
            return Console.ReadLine();
        }

    //Display player data
        public void ShowPlayer(Player player){
            ScreenUtility.WriteColoredString("Jogador " + player.Name, ConsoleColor.Black, ConsoleColor.DarkYellow);
        }

        public void ShowPlayerSub(Player player){
            ShowPlayer(player);
            //ScreenUtility.WriteColoredString(("").PadRight(40, '-'), ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.WriteLine();
        }
    }
}