using System;
using DinoGame.Models;
using DinoGame.Views;

namespace DinoGame.Controllers
{


    public class TurnController{    
        TurnView turnView = new TurnView();
        public Turn StartNewTurn(int turnNumber, Player attackPlayer, Player defensePlayer){
            return turnView.CreateTurn(turnNumber, attackPlayer, defensePlayer);
        }

        public void FinishTurn(Turn turn){
            turnView.ShowTurnResult(turn);
        }
    }
}