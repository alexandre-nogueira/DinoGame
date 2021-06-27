using System;

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
            Console.WriteLine("Jogador " + player.GetName());
        }

    }
}