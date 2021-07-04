using System;
using DinoGame.Models;
using DinoGame.Views;

namespace DinoGame.Controllers{
    public class PlayerController{
        //Create New Player

        PlayerView playerView = new PlayerView();

        public Player CreateNewPlayer(string playerNameLabel){
            playerView.playerNameLabel = playerNameLabel;
            return new Player(playerView.GetPlayerName());
        }

        public void ShowPlayer(Player player, bool title){
            playerView.ShowPlayer(player);
        }
    }
}