using System;
using DinoGame.Util;
using DinoGame.Models;

namespace DinoGame.Views{
    public class PlayerView : MainGameView{
    public string playerNameLabel;
    // { 
    //     get { return playerNameLabel; } 
    //     set { playerNameLabel  = value; } 
    // }


    //Create new player screen
        public string GetPlayerName(){
            WriteMainMenu();
            Console.Write("Nome do Jogador " + playerNameLabel + " : ");
            return Console.ReadLine();
        }
    //Display player data
        public void ShowPlayer(Player player){
            ScreenUtility.WriteColoredString("Jogador " + player.GetName(), ConsoleColor.Black, ConsoleColor.DarkYellow);
        }

        
        public void ShowPlayerSub(Player player){
            ShowPlayer(player);
            ScreenUtility.WriteColoredString(("").PadRight(40, '-'), ConsoleColor.Black, ConsoleColor.DarkYellow);
        }

    }
}