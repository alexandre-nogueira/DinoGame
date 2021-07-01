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
            ScreenUtility.WriteColoredString(attackPlayer.Name + ", sua vez!!", ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.WriteLine();
            dinossaurView.ListDinossaurs(attackPlayer.GetDinossaurs());
            attackDino = attackPlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para atacar...: "));
            WriteMainMenu();
            WriteTurn(turnNumber);
            ScreenUtility.WriteColoredString(defensePlayer.Name + ", sua vez!!", ConsoleColor.Black, ConsoleColor.DarkYellow);
            Console.WriteLine();
            dinossaurView.ListDinossaurs(defensePlayer.GetDinossaurs());
            defenseDino = defensePlayer.SelectDino(ScreenUtility.readInt("Selecione um dino para defender...: "));
            return new Turn(turnNumber, attackPlayer.Name, defensePlayer.Name, attackDino, defenseDino);
        }

        public void WriteTurn(int numeroTurn){
            ScreenUtility.WriteColoredString("Turn: " + numeroTurn + " ", ConsoleColor.Black, ConsoleColor.DarkRed);
            ScreenUtility.WriteColoredString(("").PadRight(40, '-'), ConsoleColor.Black, ConsoleColor.DarkRed);
            Console.WriteLine();
        }

        public void ShowTurnResult(Turn turn){
            System.Console.WriteLine();
            Console.WriteLine("O Player " + turn.AttackPlayer + " atacou o dino " + turn.DefenseDino.Name + 
                    " com o dino " + turn.AttackDino.Name + " e tirou " + turn.HitPoints + " pontos de vida");
            Console.WriteLine("Agora o dino " + turn.DefenseDino.Name + " tem apenas " + (turn.DefenseDino.DefensePoints - turn.HitPoints));

            Console.WriteLine("Penalidade de ataque: " + (turn.AttackPenaltyType ==1 ? "ataque" : "defesa"));

            Console.ReadKey();

        }
    }

}