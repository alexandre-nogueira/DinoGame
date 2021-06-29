using System;
using DinoGame.Models;
using DinoGame.Util;


namespace DinoGame.Views{
    public class TurnView : MainGameView{
        DinossaurView dinossaurView = new DinossaurView();
        public Turn CreateTurn(int turnNumber, Player attackPlayer, Player defensePlayer){
             Dinossaur attackDino;
             Dinossaur defenseDino;
            WriteMainMenu();
            WriteTurn(turnNumber);
            ScreenUtility.WriteColoredString(attackPlayer.GetName() + ", sua vez!!", ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.WriteLine();
            dinossaurView.ListDinossaurs(attackPlayer.GetDinossaurs());
            attackDino = attackPlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para atacar...: "));
            WriteMainMenu();
            WriteTurn(turnNumber);
            ScreenUtility.WriteColoredString(defensePlayer.GetName() + ", sua vez!!", ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.WriteLine();
            dinossaurView.ListDinossaurs(defensePlayer.GetDinossaurs());
            defenseDino = defensePlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para defender...: "));
            return new Turn(turnNumber, attackPlayer.GetName(), defensePlayer.GetName(), attackDino, defenseDino);
        }

        public void WriteTurn(int numeroTurn){
            ScreenUtility.WriteColoredString("Turn: " + numeroTurn + " ", ConsoleColor.Black, ConsoleColor.DarkRed);
            ScreenUtility.WriteColoredString(("").PadRight(40, '-'), ConsoleColor.Black, ConsoleColor.DarkRed);
            Console.WriteLine();
        }

        public void ShowTurnResult(Turn turn){
            Console.WriteLine("O Player " + turn.GetAttackPlayer() + " atacou o dino " + turn.GetDefenseDino().GetName() + 
                    " com o dino " + turn.GetAttackDino().GetName() + " e tirou " + turn.hitPoints + " pontos de vida");
            Console.WriteLine("Agora o dino " + turn.GetDefenseDino().GetName() + " tem apenas " + turn.GetDefenseDino().GetDefensePoints());

            Console.WriteLine("Penalidade de ataque: " + (turn.attackPenaltyType ==1 ? "ataque" : "defesa"));

            Console.ReadKey();

        }
    }

}